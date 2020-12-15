﻿using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Services;

using WindowsFormsUI.AdminMainForm;
using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminTimetableCreationPresenter : BasePartialPresenter<ITimetableCreationView, User>
    {
        private User _user;
        private IServiceProvider _services;
        private SolverService _solverService;

        private TimetableSettings _timetableSettingsAfterCreate;
        public AdminTimetableCreationPresenter(IApplicationController controller, ITimetableCreationView view) : base(controller, view)
        {
            _services = RegisterServices();
            View.CreateTimetable += () => CreateTimetable().Wait();
            View.TrainTimetable += () => TrainTimetable().Wait();
            View.SaveTimetableSettings += () => SaveSettings();
            View.SaveTimetableToDatabase += () => SaveToDatabase().Wait();
            View.ShowInUserForm += () => ShowInUserForm();
            View.DefaultTimetableSettingsChecked += () => SetDefaultSettings();
            View.CancelTimetableProcessing += () => _solverService?.Cancel();
            View.LoadTimetableData += () => View.SetTimetableSettings(TimetableDefaultSettings.Settings, true);
        }

        private void SetDefaultSettings()
        {
            if (View.IsDefaultTimetableSettings)
                View.SetTimetableSettings(TimetableDefaultSettings.Settings, true);
            else View.SetTimetableSettings(GetSavedSettings(), false);
        }

        private void ShowInUserForm()
        {
            try
            {
                View.FromThread(() => Controller.GetPresenter<UserPresenter, User>()
                    .RunAsDialog(new TimetableViewInfo
                    {
                        DateTime = DateTime.Now,
                        Days = View.DaysWeek,
                        Hours = View.HourDay,
                        Id = 0,
                        TimetableView = View.History.Count > 0 ?
                        _solverService
                        .GetNormalizedView(View.History.Peek())
                        .AsTimetableViewWithInclude()
                        .ToList() :
                        throw new InvalidOperationException("Расписание не создано. Нечего тут показывать")
                    }));
            }
            catch (InvalidOperationException exception)
            {
                WinFormStaticHelper.ShowErrorMsgBox(exception.Message);
            }
        }

        private async Task SaveToDatabase()
        {
            try
            {
                if (View.History.Count < 0)
                    throw new InvalidOperationException("Необходимо создать расписание");
                await _solverService.SaveToDatabase(View.History.Peek());
                MessageBox.Show("Сохранено успешно", "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                WinFormStaticHelper.ShowErrorMsgBox(e.Message);
            }
        }

        private TimetableSettings GetSavedSettings()
        {
            return new TimetableSettings
            {
                DaysWeek = Properties.Settings.Default.DaysWeek,
                HoursDay = Properties.Settings.Default.HoursDay,
                MaxIterations = Properties.Settings.Default.MaxIterations,
                PartOfBest = Properties.Settings.Default.PartOfBest,
                PopulationCount = Properties.Settings.Default.PopulationCount,
                SemestersPart = Properties.Settings.Default.SemesterPart
            };
        }
        private void SaveSettings()
        {
            if (!View.IsDefaultTimetableSettings)
            {
                Properties.Settings.Default.DaysWeek = View.DaysWeek;
                Properties.Settings.Default.HoursDay = View.HourDay;
                Properties.Settings.Default.MaxIterations = View.IterationsCount;
                Properties.Settings.Default.PartOfBest = View.PartOfBest;
                Properties.Settings.Default.PopulationCount = View.PopulationCount;
                Properties.Settings.Default.SemesterPart = View.SemestersPart;
                Properties.Settings.Default.Save();
                View.LogProccessing("Настройки сохранены");
            }
            else View.LogProccessing("Используются настройки по умолчанию");
        }

        public override void Run(User argument)
        {
            _user = argument;
        }

        private IServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILogger), View.SolverLogger)
                .AddScoped<DefaultSolverService>()
                .BuildServiceProvider();
        }

        private async Task CreateTimetable()
        {
            try
            {
                View.IsTimetableProcessing = true;
                if (View.IsDefaultTimetableSettings)
                    _timetableSettingsAfterCreate = TimetableDefaultSettings.Settings;
                else _timetableSettingsAfterCreate = GetSavedSettings();
                View.LogProccessing($"Загружаем необходимые данные");
                _solverService ??= _services.GetService<DefaultSolverService>().Load();
                _solverService.SetSettings(_timetableSettingsAfterCreate);
                View.LogProccessing($"Начинаем создание расписания");
                View.History.Push(await _solverService.CreateAsync());
                if (View.History.Peek().Timetable.Exception != null)
                    throw View.History.Peek().Timetable.Exception;
                View.LogProccessing("Расписание создано");
            }
            catch (OperationCanceledException)
            {
                View.LogProccessing("Создание отменено");
            }
            catch (Exception e)
            {
                WinFormStaticHelper.ShowErrorMsgBox(e.Message);
            }
            finally
            {
                View.IsTimetableProcessing = false;
            }
        }

        private async Task TrainTimetable()
        {
            if(View.History.Count == 0)
            {
                View.LogProccessing("Необходимо создать расписание");
                return;
            }
            var tmpTable = View.History.Peek();
            try
            {
                View.IsTimetableProcessing = true;
                _solverService.SetSettings(_timetableSettingsAfterCreate);
                _timetableSettingsAfterCreate.MaxIterations = View.IterationsCount;
                _timetableSettingsAfterCreate.PartOfBest = View.PartOfBest;
                _timetableSettingsAfterCreate.PopulationCount = View.PopulationCount;
                var trainCount = View.TrainCount;
                for (int i = 0; i < trainCount; i++)
                {
                    tmpTable = await _solverService.TrainAsync(tmpTable?.Timetable);
                    View.LogProccessing($"Тренировка №{i+1} завершена");
                }
                if (tmpTable.Timetable.Exception != null)
                    throw tmpTable.Timetable.Exception;
            }
            catch (OperationCanceledException)
            {
                View.LogProccessing($"Тренировка отменена");
            }
            catch (AggregateException)
            {
                View.LogProccessing($"Тренировка отменена");
            }
            catch (Exception e)
            {
                WinFormStaticHelper.ShowErrorMsgBox(e.Message);
            }
            finally
            {
                View.IsTimetableProcessing = false;
                if (tmpTable != View.History.Peek())
                    View.History.Push(tmpTable);
            }
        }
    }
}
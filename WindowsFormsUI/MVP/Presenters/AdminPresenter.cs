using DataAccess.Entities;
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
    public class AdminPresenter : BasePresenter<IAdminView, User>
    {
        private User _user;
        private IServiceProvider _services;
        private SolverService _solverService;
        private TimetableSettings _timetableSettings;
        public AdminPresenter(IApplicationController controller, IAdminView view) : base(controller, view)
        {
            _services = RegisterServices();
            View.CreateTimetable += () => CreateTimetable().Wait();
            View.TrainTimetable += () => TrainTimetable().Wait();
            View.SaveSettings += () => SaveSettings();
            View.SaveTimetableToDatabase += () => SaveToDatabase().Wait();
            View.ShowInUserForm += () => ShowInUserForm();
            View.DefaultSettingsChecked += () => SetDefaultSettings();
            View.CancelTimetableProcessing += () => _solverService?.Cancel();
            View.FormLoaded += () => View.SetTimetableSettings(TimetableDefaultSettings.Settings);
        }

        private void SetDefaultSettings()
        {
            if (View.IsDefaultSettings)
            {
                _timetableSettings = TimetableDefaultSettings.Settings;
                View.SetTimetableSettings(_timetableSettings);
                View.SetReadOnlySettingsState(true);
            }
            else View.SetReadOnlySettingsState(false);
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
                        .GetNormalizedViewWithInclude()
                        .ToList() :
                        throw new InvalidOperationException("Расписание не создано. Нечего тут показывать")
                    }));
            }
            catch (InvalidOperationException exception)
            {
                IdkHelper.ShowErrorMsgBox(exception.Message);
            }
        }

        private async Task SaveToDatabase()
        {
            try
            {
                await _solverService.SaveToDatabase(View.History.Peek());
                MessageBox.Show("Сохранено успешно", "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                IdkHelper.ShowErrorMsgBox(e.Message);
            }
        }

        private void SaveSettings()
        {
            _timetableSettings = new TimetableSettings
            {
                DaysWeek = View.DaysWeek,
                HoursDay = View.HourDay,
                MaxIterations = View.IterationsCount,
                PartOfBest = View.PartOfBest,
                PopulationCount = View.PopulationCount,
                SemestersPart = View.SemestersPart
            };
            View.LogProccessing("Настройки сохранены");
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
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
                View.LogProccessing($"Загружаем необходимые данные");
                _solverService ??= _services.GetService<DefaultSolverService>();
                _solverService.SetSettings(_timetableSettings);
                View.LogProccessing($"Начинаем создание расписания");
                View.History.Push(await _solverService.CreateAsync());
                View.LogProccessing("Расписание создано");
            }
            catch (OperationCanceledException)
            {
                View.LogProccessing("Создание отменено");
            }
            catch (Exception e)
            {
                IdkHelper.ShowErrorMsgBox(e.Message);
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
                _solverService.SetSettings(_timetableSettings);
                var trainCount = View.TrainCount;
                    
                for (int i = 0; i < trainCount; i++)
                {
                    tmpTable = await _solverService.TrainAsync(tmpTable?.Timetable);
                    View.LogProccessing($"Тренировка №{i} завершена");
                }
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
                IdkHelper.ShowErrorMsgBox(e.Message);
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

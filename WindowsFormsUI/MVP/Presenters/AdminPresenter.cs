using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.Services;

using WindowsFormsUI.AdminMainForm;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminPresenter : BasePresenter<IAdminView, User>
    {
        private User _user;
        private IServiceProvider _services;
        private SolverService _solverService;
        public AdminPresenter(IApplicationController controller, IAdminView view) : base(controller, view)
        {
            _services = RegisterServices();
            View.CreateTimetable += () => CreateTimetableAsync().Wait(); 
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

        //private void ApplyAlgSettings()
        //{
        //    TimetableDefaultSettings.MaxIterations = (int)numericIterationsCount.Value;
        //    TimetableDefaultSettings.PartOfBest = (int)numericPartOfBest.Value;
        //    TimetableDefaultSettings.PopulationCount = (int)numericPopulationCount.Value;
        //}

        //private void ApplyTimetableSettings()
        //{
        //    TimetableDefaultSettings.DaysWeek = (int)numericDaysWeek.Value;
        //    TimetableDefaultSettings.HoursDay = (int)numericHoursDay.Value;
        //    TimetableDefaultSettings.SemestersPart = (SemestersParts)numericSemesterPart.Value - 1;
        //}

        private async Task CreateTimetableAsync()
        {
            try
            {
                if(_solverService is null)
                    _solverService = _services.GetService<DefaultSolverService>();
                View.History.Push(await _solverService.CreateAsync());
                //ApplyAlgSettings();
                //ApplyTimetableSettings();
                //pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = true);
                //rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Загружаем необходимые данные\r\n"));
                //rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Начинаем создание расписания\r\n"));
                //History.Push();
                //rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"{History.Peek().Message}\r\n"));

            }
            catch (OperationCanceledException)
            {
                //rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Создание отменено\r\n"));
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = false);
            }
        }

        //private UserForm CreateUserForm()
        //{
        //    return new UserForm(null/*, new User()*/)
        //        .AddTimetableViewInfo(new TimetableViewInfo()
        //         {
        //             Days = _timetableResult.Peek().Timetable.DaysWeek,
        //             Hours = _timetableResult.Peek().Timetable.HoursDay,
        //             Id = 0,
        //             DateTime = DateTime.Now,
        //             IsVerified = true,
        //             TimetableView = _solver.GetNormalizedView(_timetableResult.Peek())
        //            .GetNormalizedViewWithInclude()
        //            .ToList()
        //        });
        //}

        //private void TrainTimetable()
        //{
        //    try
        //    {
        //        ApplyAlgSettings();
        //        ApplyTimetableSettings();
        //        if (History.Peek()?.Timetable is null)
        //        {
        //            rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Необходимо создать расписание\r\n"));
        //            return;
        //        }
        //        pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = true);
        //        var trainCount = numericTrainCount.Value;
        //        for (int i = 0; i < trainCount; i++)
        //        {
        //            History.Push(_solver.TrainAsync(History.Peek()?.Timetable).Result);
        //            rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"{History.Peek().Message}\r\n"));
        //        }
        //        rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Тренировка завершена\r\n"));
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Тренировка отменена\r\n"));
        //    }
        //    catch (AggregateException)
        //    {
        //        rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Тренировка отменена\r\n"));
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = false);
        //    }
        //}

        //private void SaveToDatabase()
        //{
        //    try
        //    {
        //        _solver.SaveToDatabase(History.Peek()).Wait();
        //        MessageBox.Show("Сохранено успешно", "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}

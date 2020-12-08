using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.Entities;

using Microsoft.Extensions.DependencyInjection;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.Services;

using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm
    {
        private SolverService _solver;
        private Stack<TimetableResult> _timetableResult;
        private async Task CreateTimetableAsync()
        {
            TimetableSettings.MaxIterations = 10;
            try
            {
                pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = true);
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Загружаем необходимые данные\r\n"));
                if(_solver is null)
                    await Task.Run(() => { _solver = _services.GetService<DefaultSolverService>(); });
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Начинаем создание расписания\r\n"));
                _timetableResult.Push(await _solver.CreateAsync());
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"{_timetableResult.Peek().Message}\r\n"));
                
            }
            catch (OperationCanceledException)
            {
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Создание отменено\r\n"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = false);
            }
        }

        private UserForm CreateUserForm()
        {
            return new UserForm(new User())
                .AddTimetableViewInfo(new TimetableViewInfo()
                 {
                     Days = _timetableResult.Peek().Timetable.DaysWeek,
                     Hours = _timetableResult.Peek().Timetable.HoursDay,
                     Id = 0,
                     DateTime = DateTime.Now,
                     IsVerified = true,
                     TimetableView = _solver.GetNormalizedView(_timetableResult.Peek())
                    .GetNormalizedViewWithInclude()
                    .ToList()
                });
        }

        private void TrainTimetable()
        {
            try
            {
                if(_timetableResult.Peek()?.Timetable is null)
                {
                    rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Необходимо создать расписание\r\n"));
                    return;
                }
                pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = true);
                var trainCount = numericTrainCount.Value;
                for (int i = 0; i < trainCount; i++)
                {
                    _timetableResult.Push(_solver.TrainAsync(_timetableResult.Peek()?.Timetable).Result);
                    rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"{_timetableResult.Peek().Message}\r\n"));
                }
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Тренировка завершена\r\n"));
            }
            catch (OperationCanceledException)
            {
                rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"Тренировка отменена\r\n"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = false);
            }
        }

        private void SaveToDatabase()
        {
            try
            {
                _solver.SaveToDatabase(_timetableResult.Peek()).Wait();
                MessageBox.Show("Сохранено успешно", "Расписание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

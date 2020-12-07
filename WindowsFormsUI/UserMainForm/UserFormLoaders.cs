
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands;
using WindowsFormsUI.FormCommands.DataGridCommands;
using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        private CommandInvoker<DataGridViewCommand> _gridCommandInvoker;
        private DataGridViewCommandReceiver _gridCommandReceiver;

        private void ShowTimetable()
        {
            _gridCommandInvoker.SetCommand(new TimetableCommand(
                groupsList.GetSelectedItem<GroupWrapper>()?.Group,
                _viewInfo,
                _gridCommandReceiver))
                .Run();
        }

        private void ShowTimetablePlan()
        {
            _gridCommandInvoker.SetCommand(new TimetablePlanCommand(
                specialtyList.GetSelectedItem<SpecialtyWrapper>()?.Specialty,
                _gridCommandReceiver))
                .Run();
        }

        private void ShowTeacherInfo()
        {
            _gridCommandInvoker.SetCommand(new TeacherInfoCommand(
                _gridCommandReceiver, teacherList.GetSelectedItem<TeacherWrapper>()?.Teacher))
                .Run();
        }

        private void ShowTeacherTimetable()
        {
            _gridCommandInvoker.SetCommand(new TeacherTimetableCommand(
                timetableTeacherList.GetSelectedItem<TeacherWrapper>()?.Teacher,
                _viewInfo,
                _gridCommandReceiver))
                .Run();
        }

        private async Task InitDataAsync()
        {
            _timetableView = await Task.Run(() =>
             new TimetableViewData(
                new LessonContext(),
                new SpecialtyContext(),
                new PlanContext(),
                new TimetableViewContext()));

            _gridCommandInvoker = new CommandInvoker<DataGridViewCommand>();
            _gridCommandReceiver = new DataGridViewCommandReceiver(timetableGridView, _timetableView);

            await InitSpecialtiesAndGroups();
            await InitTeachers();

            preDataLoaderPanel.Visible = false;
        }

        private async Task InitSpecialtiesAndGroups()
        {
            await Task.Run(() =>
            {
                foreach (var specialty in _timetableView.Specialties.GetAll().OrderBy(x => x.Id))
                {
                    foreach (var group in specialty.Groups.OrderBy(x => x.Id))
                        groupsList.Invoke(() => groupsList.Items.Add(new GroupWrapper(group)));
                    specialtyList.Invoke(() => specialtyList.Items.Add(new SpecialtyWrapper(specialty)));
                }
            });
            groupsList.Update();
            specialtyList.Update();
            btnShowView.Enabled = true;
            btnShowPlan.Enabled = true;
        }

        private async Task InitTeachers()
        {
            await Task.Run(() =>
            {
                foreach (var teacher in _timetableView.TeacherSubject.GetNamedTeachers().OrderBy(x => x.Lastname))
                {
                    teacherList.Invoke(() => teacherList.Items.Add(new TeacherWrapper(teacher)));
                    timetableTeacherList.Invoke(() => timetableTeacherList.Items.Add(new TeacherWrapper(teacher)));
                }
            });
            btnShowTeachers.Enabled = true;
            btnTimetableTeacher.Enabled = true;
        }

    }
}

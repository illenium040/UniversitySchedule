
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

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        private DataGridViewCommandInvoker _gridCommandInvoker;
        private DataGridViewCommandReceiver _gridCommandReceiver;

        private Dictionary<int, string> _ruDaysOfWeek = new Dictionary<int, string>
        {
            {1, "Понедельник" },
            {2, "Вторник" },
            {3, "Среда" },
            {4, "Четверг" },
            {5, "Пятница" },
            {6, "Суббота" },
            {7, "Воскресенье" },
        };

        private void ShowTimetable()
        {
            var group = groupsList.GetSelectedItem<GroupWrapper>()?.Group;
            var view = _timetableView.TimetableView.GetLastUpdated();

            var groupsId = group is null
                ? view.TimetableView.Select(x => x.GroupId).Distinct().OrderBy(x => x).ToList()
                : new List<int>() { group.Id };

            var visualizer = new GridVisualizer(timetableGridView)
                .AddSettings(new GridVisualizerSettings())
                .AddColumns(() => groupsId.Select(x => x.ToString()))
                .AddRowsByColumn(() => groupsId
                    .Select(gId => view.TimetableView.Where(tv => tv.GroupId == gId).OrderBy(x => x.GroupId))
                    .Select(tViewList =>
                        Enumerable.Repeat<object>(null, view.Days * view.Hours).ToList()
                        .ForEachInList(x => tViewList
                            .Select(tView => x[tView.Day * view.Hours + tView.Hour]
                            = $"{tView.Subject.FullName} \r\n {tView.Teacher.ShortFirstname} {tView.Teacher.Lastname}")
                        .ToList())));

            for (int i = view.Days * view.Hours - view.Hours, j = view.Days; i >= 0; i -= view.Hours, j--)
                timetableGridView.Invoke((grid) => grid.Rows.Insert(i, $"{_ruDaysOfWeek[j]}"));
        }

        private void ShowTimetablePlan()
        {
            var specialty = specialtyList.GetSelectedItem<SpecialtyWrapper>()?.Specialty;
            if (specialty is null) return;
            var specialtyPlanInfo = _timetableView.PlansInformation.GetPlanInformationBySpecialty(specialty.Id);

            new GridVisualizer(timetableGridView)
                .AddSettings(new GridVisualizerSettings())
                .AddColumns(new List<string> { "Код", "Предмет" }
                            .AppendWithIndex(specialtyPlanInfo.HourPlans.First().SemestersCount, i => $"Семестр {i + 1}"))
                .AddRowsByRow(()=>  specialtyPlanInfo.HourPlans.OrderByDescending(x => x[0])
                        .Select(x => new List<object> { x.Code, x.Subject.FullName }
                                .AppendWithIndex(x.SemestersCount, i => x[i].Value).ToList())
                        .ToList());
        }

        private void ShowTeacherInfo()
        {
            _gridCommandInvoker.SetCommand(
                new ShowTeacherInfoCommand(_gridCommandReceiver, teacherList.GetSelectedItem<TeacherWrapper>()?.Teacher))
                .Run();
        }

        private void ShowTeacherTimetable()
        {
            var teacher = timetableTeacherList.GetSelectedItem<TeacherWrapper>()?.Teacher;
            if (teacher is null) return;
            var view = _timetableView.TimetableView.GetLastUpdated();
            var timetable = view.TimetableView.Where(x => x.TeacherId == teacher.Id).ToList();

            var visualizer = new GridVisualizer(timetableGridView)
                .AddColumns(timetable.OrderBy(x => x.GroupId).Distinct().Select(x => x.GroupId.ToString()))
                .AddRowsByColumn(() => 
                timetable.OrderBy(x => x.GroupId).Distinct().Select(x => x.GroupId)
                    .Select(gId => timetable.Where(tv => tv.GroupId == gId).OrderBy(x => x.GroupId))
                    .Select(tViewList =>
                        Enumerable.Repeat<object>(null, view.Days * view.Hours).ToList()
                        .ForEachInList(x => tViewList
                            .Select(tView => x[tView.Day * view.Hours + tView.Hour]
                            = $"{tView.Subject.FullName} \r\n {tView.Teacher.ShortFirstname} {tView.Teacher.Lastname}")
                        .ToList())));

            for (int i = view.Days * view.Hours - view.Hours, j = view.Days; i >= 0; i -= view.Hours, j--)
                timetableGridView.Invoke((grid) => grid.Rows.Insert(i, $"{_ruDaysOfWeek[j]}"));
        }

        private async Task LoadDataAsync()
        {
            _timetableView = await Task.Run(() =>
             new TimetableViewData(
                new LessonContext(),
                new SpecialtyContext(),
                new PlanContext(),
                new TimetableViewContext()));
            await InitSpecialtiesAndGroups();
            dataLoadStateText.Text = "Загружаем список преподавателей";
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

using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.FormCommands.DataGridCommands
{
    public class TeacherTimetableCommand : DataGridViewCommand
    {
        private Teacher _teacher;
        public TeacherTimetableCommand(Teacher teacher, DataGridViewCommandReceiver receiver) : base(receiver)
        {
            _teacher = teacher;
        }

        public override void Execute()
        {
            if (_teacher is null) return;
            var view = Receiver.ViewData.TimetableView.GetLastUpdated();
            var timetable = view.TimetableView.Where(x => x.TeacherId == _teacher.Id).ToList();

            var visualizer = new GridVisualizer(Receiver.GridView)
                .AddColumns(timetable.OrderBy(x => x.GroupId).Select(x => x.GroupId.ToString()).Distinct())
                .AddRowsByColumn(() =>
                timetable.OrderBy(x => x.GroupId).Select(x => x.GroupId).Distinct()
                    .Select(gId => timetable.Where(tv => tv.GroupId == gId).OrderBy(x => x.GroupId))
                    .Select(tViewList =>
                        Enumerable.Repeat<object>(null, view.Days * view.Hours).ToList()
                        .ForEachInList(x => tViewList
                            .Select(tView => x[tView.Day * view.Hours + tView.Hour]
                            = $"{tView.Subject.FullName} \r\n {tView.Teacher.ShortFirstname} {tView.Teacher.Lastname}")
                        .ToList())));

            AppendDaysOfWeek(view);
        }
    }
}

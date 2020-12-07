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
        private TimetableViewInfo _viewInfo;
        public TeacherTimetableCommand(Teacher teacher, TimetableViewInfo viewInfo,
            DataGridViewCommandReceiver receiver) : base(receiver)
        {
            _teacher = teacher;
            _viewInfo = viewInfo;
        }

        public override void Execute()
        {
            if (_teacher is null) return;
            var timetable = _viewInfo.TimetableView.Where(x => x.TeacherId == _teacher.Id).ToList();
            if (timetable.Count == 0) return;
            GridVisualizer
                .AddColumns(timetable.OrderBy(x => x.GroupId).Select(x => x.GroupId.ToString()).Distinct())
                .AddRowsByColumn(() =>
                timetable.OrderBy(x => x.GroupId).Select(x => x.GroupId).Distinct()
                    .Select(gId => timetable.Where(tv => tv.GroupId == gId).OrderBy(x => x.GroupId))
                    .Select(tViewList =>
                        Enumerable.Repeat<object>(null, _viewInfo.Days * _viewInfo.Hours).ToList()
                        .ForEachInList(x => tViewList
                            .Select(tView => x[tView.Day * _viewInfo.Hours + tView.Hour]
                            = $"{tView.Subject.FullName} \r\n {tView.Teacher.ShortFirstname} {tView.Teacher.Lastname}")
                        .ToList())));

            AppendDaysOfWeek(_viewInfo);
            GridVisualizer.Resize();
        }
    }
}

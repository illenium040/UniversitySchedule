using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.FormCommands.DataGridCommands
{
    public class TimetableCommand : DataGridViewCommand
    {
        private Group _group;
        public TimetableCommand(Group group, DataGridViewCommandReceiver receiver)
            : base(receiver)
        {
            _group = group;
        }

        public override void Execute()
        {
            var view = Receiver.ViewData.TimetableView.GetLastUpdated();

            var groupsId = _group is null
                ? view.TimetableView.Select(x => x.GroupId).Distinct().OrderBy(x => x).ToList()
                : new List<int>() { _group.Id };

            GridVisualizer
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

            AppendDaysOfWeek(view);
            GridVisualizer.Resize();
        }
    }
}

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
        private TimetableViewInfo _viewInfo;
        public TimetableCommand(Group group, TimetableViewInfo viewInfo,
            DataGridViewCommandReceiver receiver)
            : base(receiver)
        {
            _group = group;
            _viewInfo = viewInfo;
        }

        public override void Execute()
        {
            var groupsId = _group is null
                ? _viewInfo.TimetableView.Select(x => x.GroupId).Distinct().OrderBy(x => x).ToList()
                : new List<int>() { _group.Id };

            GridVisualizer
                .AddSettings(new GridVisualizerSettings())
                .AddColumns(() => groupsId.Select(x => x.ToString()))
                .AddRowsByColumn(() => groupsId
                    .Select(gId => _viewInfo.TimetableView.Where(tv => tv.GroupId == gId).OrderBy(x => x.GroupId))
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

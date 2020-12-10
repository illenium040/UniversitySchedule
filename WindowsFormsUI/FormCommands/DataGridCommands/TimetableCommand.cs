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
        private IEnumerable<Group> _groups;
        private TimetableViewInfo _viewInfo;
        public TimetableCommand(IEnumerable<Group> groups, TimetableViewInfo viewInfo)
        {
            _groups = groups;
            _viewInfo = viewInfo;
        }

        public override void Execute()
        {
            if (Receiver is null) throw new ArgumentNullException(nameof(Receiver));
            var groupsId = _groups.Select(x => x.Id).Distinct().OrderBy(x => x).ToList();

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

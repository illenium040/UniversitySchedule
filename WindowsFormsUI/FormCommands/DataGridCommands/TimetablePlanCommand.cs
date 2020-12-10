using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.FormCommands.DataGridCommands
{
    public class TimetablePlanCommand : DataGridViewCommand
    {
        private PlanInformation _planInfo;
        public TimetablePlanCommand(PlanInformation planInfo)
        {
            _planInfo = planInfo;
        }

        public override void Execute()
        {
            if (Receiver is null) throw new ArgumentNullException(nameof(Receiver));
            GridVisualizer
                .AddSettings(new GridVisualizerSettings())
                .AddColumns(new List<string> { "Код", "Предмет" }
                            .AppendWithIndex(_planInfo.HourPlans.First().SemestersCount, i => $"Семестр {i + 1}"))
                .AddRowsByRow(() => _planInfo.HourPlans.OrderByDescending(x => x[0])
                        .Select(x => new List<object> { x.Code, x.Subject.FullName }
                                .AppendWithIndex(x.SemestersCount, i => x[i].Value).ToList())
                        .ToList())
                .Resize();
        }
    }
}

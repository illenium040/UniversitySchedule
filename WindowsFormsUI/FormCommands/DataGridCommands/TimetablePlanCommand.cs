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
        private Specialty _specialty;
        public TimetablePlanCommand(Specialty specialty,
            DataGridViewCommandReceiver receiver) : base(receiver)
        {
            _specialty = specialty;
        }

        public override void Execute()
        {
            if (_specialty is null) return;
            var specialtyPlanInfo = Receiver.ViewData.PlansInformation.GetPlanInformationBySpecialty(_specialty.Id);

            GridVisualizer
                .AddSettings(new GridVisualizerSettings())
                .AddColumns(new List<string> { "Код", "Предмет" }
                            .AppendWithIndex(specialtyPlanInfo.HourPlans.First().SemestersCount, i => $"Семестр {i + 1}"))
                .AddRowsByRow(() => specialtyPlanInfo.HourPlans.OrderByDescending(x => x[0])
                        .Select(x => new List<object> { x.Code, x.Subject.FullName }
                                .AppendWithIndex(x.SemestersCount, i => x[i].Value).ToList())
                        .ToList())
                .Resize();
        }
    }
}

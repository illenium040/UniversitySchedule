using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.FormCommands.DataGridCommands
{
    public class TeacherInfoCommand : DataGridViewCommand
    {
        private IEnumerable<Teacher> _teachers;
        public TeacherInfoCommand(IEnumerable<Teacher> teachers)
        {
            _teachers = teachers;
        }
        public override void Execute()
        {
            if (Receiver is null) throw new ArgumentNullException(nameof(Receiver));
            GridVisualizer
                .AddColumns(_teachers.Select(t => $"{t.ShortFirstname} {t.Lastname}"))
                .AddRowsByColumn(_teachers.Select(t =>
                    t.TeacherSubject.Select(x => x.Subject).Distinct().Select(x => x.FullName)))
                .Resize();
        }
    }
}

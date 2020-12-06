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
        private Teacher _teacher;
        public TeacherInfoCommand(DataGridViewCommandReceiver receiver, Teacher teacher)
            : base(receiver)
        {
            _teacher = teacher;
        }
        public override void Execute()
        {
            var teachers = _teacher is null
                ? Receiver.ViewData.TeacherSubject.GetNamedTeachers()
                : Receiver.ViewData.TeacherSubject.GetByTeacher(_teacher.Id).Select(x => x.Teacher).Distinct().ToList();
            GridVisualizer
                .AddColumns(teachers.Select(t => $"{t.ShortFirstname} {t.Lastname}"))
                .AddRowsByColumn(teachers.Select(t =>
                    t.TeacherSubject.Select(x => x.Subject).Distinct().Select(x => x.FullName)))
                .Resize();
        }
    }
}

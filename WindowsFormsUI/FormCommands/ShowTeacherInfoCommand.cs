using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI.FormCommands
{
    public class ShowTeacherInfoCommand : DataGridViewCommand
    {
        private Teacher _teacher;
        public ShowTeacherInfoCommand(DataGridViewCommandReceiver receiver, Teacher teacher)
            : base(receiver)
        {
            _teacher = teacher;
        }
        public override GridVisualizer Execute()
        {
            var teachers = _teacher is null
                ? Receiver.ViewData.TeacherSubject.GetNamedTeachers()
                : Receiver.ViewData.TeacherSubject.GetByTeacher(_teacher.Id).Select(x => x.Teacher).Distinct().ToList();
            return new GridVisualizer(Receiver.GridView)
                .AddColumns(teachers.Select(t => $"{t.ShortFirstname} {t.Lastname}"))
                .AddRowsByColumn(teachers.Select(t =>
                    t.TeacherSubject.Select(x => x.Subject).Distinct().Select(x => x.FullName)));
        }
    }
}


using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands;
using WindowsFormsUI.FormCommands.DataGridCommands;
using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        private void VisualizeGridView(Action gridAction)
        {
            gridAction();
            timetableGridView.Invoke(() =>
            {
                timetableGridView.Visible = true;
                timetableGridView.Update();
            });
            dataLoadStatePanel.Invoke(() => dataLoadStatePanel.Visible = false);
        }

        public void InitData(TimetableViewInfo info)
        {
            TimetableViewInfo = info;
            _gridCommandInvoker = new CommandInvoker<DataGridViewCommand>();
            _gridCommandReceiver = new DataGridViewCommandReceiver(timetableGridView);
        }

        private void InitSpecialtiesAndGroups(IEnumerable<Specialty> specialties)
        {
            foreach (var specialty in specialties.OrderBy(x => x.Id))
            {
                foreach (var group in specialty.Groups.OrderBy(x => x.Id))
                    groupsList.Invoke(() => groupsList.Items.Add(new GroupWrapper(group)));
                specialtyList.Invoke(() => specialtyList.Items.Add(new SpecialtyWrapper(specialty)));
            }
            groupsList.Invoke(() => groupsList.Update());
            specialtyList.Invoke(() => specialtyList.Update());
            btnShowView.Invoke(() => btnShowView.Enabled = true);
            btnShowPlan.Invoke(() => btnShowPlan.Enabled = true);
            btnSaveAsPdf.Invoke(() => btnSaveAsPdf.Enabled = true);
        }

        private void InitTeachers(IEnumerable<Teacher> namedTeachers)
        {
            foreach (var teacher in namedTeachers.OrderBy(x => x.Lastname))
            {
                teacherList.Invoke(() => teacherList.Items.Add(new TeacherWrapper(teacher)));
                timetableTeacherList.Invoke(() => timetableTeacherList.Items.Add(new TeacherWrapper(teacher)));
            }
            btnShowTeachers.Invoke(() => btnShowTeachers.Enabled = true);
            btnTimetableTeacher.Invoke(() => btnTimetableTeacher.Enabled = true);
        }

    }
}

using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        public Group SelectedGroupForTimetable
        {
            get { return groupsList.GetSelectedItem<GroupWrapper>()?.Group; }
        }

        public Specialty SelectedSpecialtyForPlan
        {
            get { return specialtyList.GetSelectedItem<SpecialtyWrapper>()?.Specialty; }
        }

        public Teacher SelectedTeacherAbout
        {
            get { return teacherList.GetSelectedItem<TeacherWrapper>()?.Teacher; }
        }

        public Teacher SelectedTeacherForTimetable
        {
            get { return timetableTeacherList.GetSelectedItem<TeacherWrapper>()?.Teacher; }
        }

        public TimetableViewInfo TimetableViewInfo
        {
            get { return _viewInfoInstance ??= _timetableView.TimetableView.GetLastUpdated(); }
        }

        public bool IsPreLoading
        {
            get { return preDataLoaderPanel.Visible; }
            set { preDataLoaderPanel.Invoke(() => preDataLoaderPanel.Visible = value); }
        }

        public void VisualizeGrid(DataGridViewCommand command)
        {
            if (command != null)
            {
                VisualizeGridView(() =>
                    _gridCommandInvoker.SetCommand(
                        command.AddReceiver(_gridCommandReceiver))
                        .Run());
            }
            else IdkHelper.ShowErrorMsgBox("Параметр не задан или задан неверно");
        }

        public IUserView AddTimetableViewInfo(TimetableViewInfo viewInfo)
        {
            _viewInfoInstance = viewInfo;
            return this;
        }

        public new void Show()
        {
            if (_context.MainForm is null)
            {
                _context.MainForm = this;
                Application.Run(_context);
            }
            else
            {
                _context.MainForm = this;
                base.Show();
            }

        }

        public void FromThread(Action action)
        {
            this.Invoke(action);
        }

        public new void Close()
        {
            if (this.InvokeRequired)
                this.Invoke(base.Close);
            else base.Close();
        }

        public void InitControlsData(IEnumerable<Specialty> specialties, IEnumerable<Teacher> teachers)
        {
            InitSpecialtiesAndGroups(specialties);
            InitTeachers(teachers);
        }

        public void SetPreLoadState(string message)
        {
            preDataLoadStateText.Invoke(() => preDataLoadStateText.Text = message);
        }
    }
}

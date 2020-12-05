using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using WindowsFormsUI.FormCommands;
using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI.UserMainForm
{
    public partial class UserForm : Form
    {
        private readonly MainForm _mainForm;
        private User _user;
        private ActionProxy _actionProxy;

        private ITimetableViewData _timetableView;

        public UserForm(MainForm form, User user)
        {
            InitializeComponent();
            _user = user;
            _mainForm = form;
            _actionProxy = new ActionProxy();
            btnShowView.Click += ShowView;
            btnShowPlan.Click += ShowPlan;
            btnShowTeachers.Click += ShowTeachers;
            btnTimetableTeacher.Click += ShowTeachersTimetable;

            FormClosing += UserForm_FormClosing;

            AddPictureBoxSettings();
            AddGridViewSettings();

        }

        private async void ShowTeachersTimetable(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(()=> VisualizeGridView(ShowTeacherTimetable));
        }

        private async void ShowTeachers(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() => VisualizeGridView(ShowTeacherInfo));
        }

        private async void ShowPlan(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() => VisualizeGridView(ShowTimetablePlan));
        }

        private async void ShowView(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() => VisualizeGridView(ShowTimetable));
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            _gridCommandInvoker = new CommandInvoker<DataGridViewCommand>();
            _gridCommandReceiver = new DataGridViewCommandReceiver(timetableGridView, _timetableView);
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Close();
        }
    }
}

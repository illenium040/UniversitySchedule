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
        private readonly User _user;
        private ActionProxy _actionProxy;

        private ITimetableViewData _timetableView;

        private TimetableViewInfo _viewInfoInstance;
        private TimetableViewInfo _viewInfo
        {
            get { return _viewInfoInstance ?? _timetableView.TimetableView.GetLastUpdated(); }
        }

        public UserForm(User user)
        {
            InitializeComponent();
            _user = user;
            _actionProxy = new ActionProxy();
            btnShowView.Click += ShowView;
            btnShowPlan.Click += ShowPlan;
            btnShowTeachers.Click += ShowTeachers;
            btnTimetableTeacher.Click += ShowTeachersTimetable;

            AddPictureBoxSettings();
            AddGridViewSettings();

        }

        public UserForm AddTimetableViewInfo(TimetableViewInfo viewInfo)
        {
            _viewInfoInstance = viewInfo;
            return this;
        }

        private async void ShowTeachersTimetable(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(()=> VisualizeGridView(ShowTeacherTimetable));
        }

        public async void ShowTeachers(object sender, EventArgs e)
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
            await InitDataAsync();
        }
    }
}

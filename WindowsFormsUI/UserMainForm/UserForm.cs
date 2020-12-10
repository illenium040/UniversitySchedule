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
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.UserMainForm
{
    public partial class UserForm : Form, IUserView
    {
        private ApplicationContext _context;
        private ActionProxy _actionProxy;

        private ITimetableViewData _timetableView;
        private TimetableViewInfo _viewInfoInstance;

        private CommandInvoker<DataGridViewCommand> _gridCommandInvoker;
        private DataGridViewCommandReceiver _gridCommandReceiver;

        public event Action ShowTimetable;
        public event Action ShowTimetablePlan;
        public event Action ShowTeachers;
        public event Action ShowTeachersTimetable;
        public event Action LoadData;

        public UserForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            _actionProxy = new ActionProxy();

            btnShowView.Click += async (sender, e) => await _actionProxy.InvokeAsync(ShowTimetable);
            btnShowPlan.Click += async (sender, e) => await _actionProxy.InvokeAsync(ShowTimetablePlan);
            btnShowTeachers.Click += async (sender, e) => await _actionProxy.InvokeAsync(ShowTeachers);
            btnTimetableTeacher.Click += async (sender, e) => await _actionProxy.InvokeAsync(ShowTeachersTimetable);
            Load += async (sender, e) => await _actionProxy.InvokeAsync(LoadData);

            AddPictureBoxSettings();
            AddGridViewSettings();
        }
    }
}

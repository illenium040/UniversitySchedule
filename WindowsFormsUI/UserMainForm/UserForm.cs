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
using WindowsFormsUI.MVP;

namespace WindowsFormsUI.UserMainForm
{
    public partial class UserForm : Form, IUserView
    {
        private ApplicationContext _context;
        private ActionProxy _actionProxy;

        private CommandInvoker<DataGridViewCommand> _gridCommandInvoker;
        private DataGridViewCommandReceiver _gridCommandReceiver;

        public string Title
        { 
            get => Text; 
            set => Text = value; 
        }

        public DataTable GridTable => timetableGridView.ToDataTable();

        public event Action ShowTimetable;
        public event Action ShowTimetablePlan;
        public event Action ShowTeachers;
        public event Action ShowTeachersTimetable;
        public event Action LoadData;
        public event Action SaveAsPdf;

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
            btnSaveAsPdf.Click += (sender, e) => _actionProxy.Invoke(SaveAsPdf);

            AddPictureBoxSettings();
            AddGridViewSettings();
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
    }
}

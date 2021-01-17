using API.TimetableCreation;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : Form, IAdminView
    {
        private TimetableFormLogger _solverLogger;
        private ApplicationContext _context;
        private ActionProxy _actionProxy;

        public AdminForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            _actionProxy = new ActionProxy();
            _solverLogger = new TimetableFormLogger(lblSolverLog);
            History = new Stack<TimetableHandler>();

            SetEventsDatabaseView();
            SetSEventsTimetableCreation();
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

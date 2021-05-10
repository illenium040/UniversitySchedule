using API.TimetableCreation;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : Form, IAdminView
    {
        private TimetableFormLogger _solverLogger;
        private ApplicationContext _context;
        private ActionProxy _actionProxy;

        private Color _onDisableColor = Color.LightGray;
        private Color _onEnableColor = Color.White;

        private Size[] _tabPagesSize = new Size[5]
        {
            new Size(805, 317),
            new Size(968, 555),
            new Size(938, 492),
            new Size(938, 492),
            new Size(938, 492)
        };

        public AdminForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            _actionProxy = new ActionProxy();
            _solverLogger = new TimetableFormLogger(lblSolverLog);
            History = new Stack<TimetableHandler>();

            checkBoxDefaultSettings_CheckStateChanged(this, null);

            SetEventsDatabaseView();
            SetEventsTimetableCreation();

            tabMainControl.SelectedIndexChanged += SelectedIndexChanged;
            this.MinimumSize = _tabPagesSize[0];
            this.Size = _tabPagesSize[0];
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            SuspendLayout();
            this.MinimumSize = _tabPagesSize[tabMainControl.SelectedIndex];
            this.Size = _tabPagesSize[tabMainControl.SelectedIndex];
            ResumeLayout();
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

        private void checkBoxDefaultSettings_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxDefaultSettings.Checked) 
                SetNumericalColor(_onDisableColor, false);
            else SetNumericalColor(_onEnableColor, true);
        }

        private void SetNumericalColor(Color c, bool isEnabled)
        {
            numericDaysWeek.BackColor = c;
            numericDaysWeek.Enabled = isEnabled;
            numericHoursDay.BackColor = c;
            numericHoursDay.Enabled = isEnabled;
            numericIterationsCount.BackColor = c;
            numericIterationsCount.Enabled = isEnabled;
            numericPartOfBest.BackColor = c;
            numericPartOfBest.Enabled = isEnabled;
            numericPopulationCount.BackColor = c;
            numericPopulationCount.Enabled = isEnabled;
            numericSemesterPart.BackColor = c;
            numericSemesterPart.Enabled = isEnabled;
            numericTrainCount.BackColor = c;
            numericTrainCount.Enabled = isEnabled;
        }
    }
}

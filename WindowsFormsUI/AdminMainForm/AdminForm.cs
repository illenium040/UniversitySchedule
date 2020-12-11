using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.Services;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.UserMainForm;

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
            History = new Stack<TimetableResult>();

            btnCreateTimetable.Click += async (sender, e) 
                => await _actionProxy.InvokeAsync(CreateTimetable);
            btnCancelTimetableCreation.Click += (sender, e) 
                => CancelTimetableProcessing();
            btnTimetableTrain.Click += async (sender, e)
                => await _actionProxy.InvokeAsync(TrainTimetable);

            btnShowUserForm.Click += async (sender, e)
                => await _actionProxy.InvokeAsync(ShowInUserForm);
            btnSaveToDatabase.Click += async (sender, e)
                => await _actionProxy.InvokeAsync(SaveTimetableToDatabase);

            checkBoxDefaultSettings.CheckedChanged += (sender, e)
                => DefaultSettingsChecked();

            btnSaveSettings.Click += (sender, e)
                => _actionProxy.Invoke(SaveSettings);
        }

        private async void ShowTimetableInUserForm(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() =>
            {
                this.Invoke(() => 
                {
                    //_userTimetableTestForm = CreateUserForm();
                    //AddOwnedForm(_userTimetableTestForm);
                    //_userTimetableTestForm.FormClosed += (s, e) => this.Invoke(() => RemoveOwnedForm(s as Form));
                    //_userTimetableTestForm.Show();
                });
            });
            
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

        public void SetReadOnlySettingsState(bool state)
        {
            numericIterationsCount.Invoke(() => numericIterationsCount.ReadOnly = state);
            numericPartOfBest.Invoke(() => numericPartOfBest.ReadOnly = state);
            numericPopulationCount.Invoke(() => numericPopulationCount.ReadOnly = state);
            numericTrainCount.Invoke(() => numericTrainCount.ReadOnly = state);
            numericDaysWeek.Invoke(() => numericDaysWeek.ReadOnly = state);
            numericHoursDay.Invoke(() => numericHoursDay.ReadOnly = state);
            numericSemesterPart.Invoke(() => numericSemesterPart.ReadOnly = state);
        }

        public void SetDefaultSettings()
        {
            var settings = TimetableDefaultSettings.Settings;
            numericIterationsCount.Invoke(() => numericIterationsCount.Value = settings.MaxIterations);
            numericPartOfBest.Invoke(() => numericPartOfBest.Value = settings.PartOfBest);
            numericPopulationCount.Invoke(() => numericPopulationCount.Value = settings.PopulationCount);
            numericTrainCount.Invoke(() => numericTrainCount.Value = 10);
            numericDaysWeek.Invoke(() => numericDaysWeek.Value = settings.DaysWeek);
            numericHoursDay.Invoke(() => numericHoursDay.Value = settings.HoursDay);
            numericSemesterPart.Invoke(() => numericSemesterPart.Value = (int)settings.SemestersPart + 1);
        }

        public void LogProccessing(string message)
        {
            rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText(message));
        }
    }
}

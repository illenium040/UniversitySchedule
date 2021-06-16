using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.Entities;

using Microsoft.Extensions.DependencyInjection;

using TimetableAlgorithm;
using API.Services;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.UserMainForm;
using API.TimetableCreation;
using WindowsFormsUI.CustomControllers;

namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm : ITimetableCreationView
    {
        private CancelButton _createTimetableBtn;
        private CancelButton _trainTimetableBtn;

        public event Action DefaultTimetableSettingsChecked;
        public event Action SaveTimetableToDatabase;
        public event Action ShowInUserForm;
        public event Action CreateTimetable;
        public event Action TrainTimetable;
        public event Action CancelTimetableProcessing;
        public event Action SaveTimetableSettings;
        public event Action LoadTimetableData;
        public event Action SaveAsPDF;

        public bool IsDefaultTimetableSettings { get { return checkBoxDefaultSettings.Checked; } }
        public Stack<TimetableHandler> History { get; private set; }

        public TimetableFormLogger SolverLogger { get { return _solverLogger; } }

        public bool IsTimetableProcessing
        {
            get { return pictureBoxTimetableCreation.Visible; }
            set { pictureBoxTimetableCreation.Invoke(() => pictureBoxTimetableCreation.Visible = value); }
        }

        public int IterationsCount { get { return (int)numericIterationsCount.Value; } }
        public int PartOfBest { get { return (int)numericPartOfBest.Value; } }
        public int PopulationCount { get { return (int)numericPopulationCount.Value; } }
        public int DaysWeek { get { return (int)numericDaysWeek.Value; } }
        public int HourDay { get { return (int)numericHoursDay.Value; } }
        public SemestersParts SemestersPart { get { return (SemestersParts)numericSemesterPart.Value - 1; } }
        public int TrainCount { get { return (int)numericTrainCount.Value; } }

        public bool IsTrainCancelRequired { get; private set; }

        public void SetTimetableSettings(TimetableSettings settings, bool isDefault)
        {
            numericIterationsCount.Invoke(() => numericIterationsCount.Value = settings.MaxIterations);
            numericPartOfBest.Invoke(() => numericPartOfBest.Value = settings.PartOfBest);
            numericPopulationCount.Invoke(() => numericPopulationCount.Value = settings.PopulationCount);
            numericTrainCount.Invoke(() => numericTrainCount.Value = 10);
            numericDaysWeek.Invoke(() => numericDaysWeek.Value = settings.DaysWeek);
            numericHoursDay.Invoke(() => numericHoursDay.Value = settings.HoursDay);
            numericSemesterPart.Invoke(() => numericSemesterPart.Value = (int)settings.SemestersPart + 1);
            SetReadOnlyTimetableSettingsState(isDefault);
        }

        public void LogProccessing(string message)
        {
            rbxTimetableResultLog.Invoke(() => rbxTimetableResultLog.AppendText($"{message}\r\n"));
        }

        

        private void SetEventsTimetableCreation()
        {
            _createTimetableBtn = new CancelButton(btnCreateTimetable);
            _createTimetableBtn.OnClick += async () =>
            {
                try
                {
                    TurnButtons(btnCreateTimetable, false);
                    await _actionProxy.InvokeAsync(CreateTimetable);
                }
                catch (Exception e)
                {
                    _createTimetableBtn.Cancel();
                }
                finally
                {
                    TurnButtons(btnCreateTimetable, true);
                }
            };
            _createTimetableBtn.OnCancel += () => CancelTimetableProcessing();
            _trainTimetableBtn = new CancelButton(btnTimetableTrain);
            _trainTimetableBtn.OnClick += async () =>
            {
                try
                {
                    TurnButtons(btnTimetableTrain, false);
                    await _actionProxy.InvokeAsync(TrainTimetable);
                }
                catch (Exception e)
                {
                    _trainTimetableBtn.Cancel();
                }
                finally
                {
                    TurnButtons(btnTimetableTrain, true);
                }
            };
            _trainTimetableBtn.OnCancel += () =>
            {
                IsTrainCancelRequired = true;
                CancelTimetableProcessing();
            };

            btnShowUserForm.Click += async (sender, e)
                => await _actionProxy.InvokeAsync(ShowInUserForm);
            btnSaveToDatabase.Click += async (sender, e)
                => await _actionProxy.InvokeAsync(SaveTimetableToDatabase);

            checkBoxDefaultSettings.CheckedChanged += (sender, e)
                => DefaultTimetableSettingsChecked?.Invoke();

            btnSaveSettings.Click += (sender, e)
                => _actionProxy.Invoke(SaveTimetableSettings);

            saveAsPDF.Click += (sender, e) =>
                _actionProxy.Invoke(SaveAsPDF);

            Load += (sender, e) => LoadTimetableData?.Invoke();
        }

        private void TurnButtons(Button sender, bool state)
        {
            TurnButton(btnCreateTimetable, sender, state);
            TurnButton(btnTimetableTrain, sender, state);
            TurnButton(btnShowUserForm, sender, state);
            TurnButton(btnSaveToDatabase, sender, state);
            TurnButton(btnSaveSettings, sender, state);
        }

        private void TurnButton(Button target, Button sender, bool state)
        {
            if (!target.Equals(sender))
                target.Enabled = state;
        }

        private void SetReadOnlyTimetableSettingsState(bool state)
        {
            numericIterationsCount.Invoke(() => numericIterationsCount.ReadOnly = state);
            numericPartOfBest.Invoke(() => numericPartOfBest.ReadOnly = state);
            numericPopulationCount.Invoke(() => numericPopulationCount.ReadOnly = state);
            numericTrainCount.Invoke(() => numericTrainCount.ReadOnly = state);
            numericDaysWeek.Invoke(() => numericDaysWeek.ReadOnly = state);
            numericHoursDay.Invoke(() => numericHoursDay.ReadOnly = state);
            numericSemesterPart.Invoke(() => numericSemesterPart.ReadOnly = state);
        }
    }
}

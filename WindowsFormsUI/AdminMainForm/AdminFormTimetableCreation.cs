using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.Entities;

using Microsoft.Extensions.DependencyInjection;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.Services;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm : ITimetableCreationView
    {
        public event Action DefaultTimetableSettingsChecked;
        public event Action SaveTimetableToDatabase;
        public event Action ShowInUserForm;
        public event Action CreateTimetable;
        public event Action TrainTimetable;
        public event Action CancelTimetableProcessing;
        public event Action SaveTimetableSettings;
        public event Action LoadTimetableData;

        public bool IsDefaultTimetableSettings { get { return checkBoxDefaultSettings.Checked; } }
        public Stack<TimetableResult> History { get; private set; }

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

        private void SetSEventsTimetableCreation()
        {
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
                => DefaultTimetableSettingsChecked?.Invoke();

            btnSaveSettings.Click += (sender, e)
                => _actionProxy.Invoke(SaveTimetableSettings);

            Load += (sender, e) => LoadTimetableData?.Invoke();
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

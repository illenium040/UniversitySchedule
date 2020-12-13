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
    partial class AdminForm : IAdminCreateTimetableView
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;

using WindowsFormsUI.AdminMainForm;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAdminView : IView
    {
        TimetableFormLogger SolverLogger { get; }
        bool IsTimetableProcessing { get; set; }
        bool IsDefaultSettings { get; }

        int IterationsCount { get; }
        int PartOfBest { get; }
        int PopulationCount { get; }
        int DaysWeek { get; }
        int HourDay { get; }
        SemestersParts SemestersPart { get; }
        int TrainCount { get; }

        Stack<TimetableResult> History { get; }

        event Action DefaultSettingsChecked;
        event Action CreateTimetable;
        event Action TrainTimetable;
        event Action SaveTimetableToDatabase;
        event Action ShowInUserForm;
        event Action CancelTimetableProcessing;
        event Action SaveSettings;
        event Action FormLoaded;

        void SetReadOnlySettingsState(bool state);
        void SetTimetableSettings(TimetableSettings settings);
        void LogProccessing(string message);
    }
}

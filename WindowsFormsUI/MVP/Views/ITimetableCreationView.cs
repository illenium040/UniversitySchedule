using System;
using System.Collections.Generic;
using System.Text;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;

using WindowsFormsUI.AdminMainForm;

namespace WindowsFormsUI.MVP.Views
{
    public interface ITimetableCreationView : IPartialView
    {
        TimetableFormLogger SolverLogger { get; }
        bool IsTimetableProcessing { get; set; }
        bool IsDefaultTimetableSettings { get; }

        int IterationsCount { get; }
        int PartOfBest { get; }
        int PopulationCount { get; }
        int DaysWeek { get; }
        int HourDay { get; }
        SemestersParts SemestersPart { get; }
        int TrainCount { get; }

        Stack<TimetableResult> History { get; }

        event Action DefaultTimetableSettingsChecked;
        event Action CreateTimetable;
        event Action TrainTimetable;
        event Action SaveTimetableToDatabase;
        event Action ShowInUserForm;
        event Action CancelTimetableProcessing;
        event Action SaveTimetableSettings;
        event Action LoadTimetableData;

        void SetTimetableSettings(TimetableSettings settings, bool isDefault);
        void LogProccessing(string message);
    }
}

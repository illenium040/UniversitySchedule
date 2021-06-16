using API.TimetableCreation;

using System;
using System.Collections.Generic;
using System.Text;

using TimetableAlgorithm;

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

        Stack<TimetableHandler> History { get; }
        bool IsTrainCancelRequired { get; }

        event Action DefaultTimetableSettingsChecked;
        event Action CreateTimetable;
        event Action TrainTimetable;
        event Action SaveTimetableToDatabase;
        event Action ShowInUserForm;
        event Action CancelTimetableProcessing;
        event Action SaveTimetableSettings;
        event Action LoadTimetableData;
        event Action SaveAsPDF;
        void SetTimetableSettings(TimetableSettings settings, bool isDefault);
        void LogProccessing(string message);
    }
}

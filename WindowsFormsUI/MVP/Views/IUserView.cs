using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.FormCommands;

namespace WindowsFormsUI.MVP.Views
{
    public interface IUserView : IView
    {
        bool IsPreLoading { get; set; }
        Group SelectedGroupForTimetable { get; }
        Specialty SelectedSpecialtyForPlan { get; }
        Teacher SelectedTeacherAbout { get; }
        Teacher SelectedTeacherForTimetable { get; }
        TimetableViewInfo TimetableViewInfo { get; }

        event Action ShowTimetable;
        event Action ShowTimetablePlan;
        event Action ShowTeachers;
        event Action ShowTeachersTimetable;
        event Action LoadData;

        void InitData(TimetableViewInfo info);
        void InitControlsData(IEnumerable<Specialty> specialties, IEnumerable<Teacher> teachers);
        void SetPreLoadState(string message);
        void VisualizeGrid(DataGridViewCommand command);
        IUserView AddTimetableViewInfo(TimetableViewInfo viewInfo);
    }
}

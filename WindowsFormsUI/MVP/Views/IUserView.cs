using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using WindowsFormsUI.FormCommands;

namespace WindowsFormsUI.MVP.Views
{
    public interface IUserView : IView
    {
        string Title { get; set; }
        bool IsPreLoading { get; set; }
        Group SelectedGroupForTimetable { get; }
        Specialty SelectedSpecialtyForPlan { get; }
        Teacher SelectedTeacherAbout { get; }
        Teacher SelectedTeacherForTimetable { get; }
        TimetableViewInfo TimetableViewInfo { get; }
        DataTable GridTable { get; }

        event Action ShowTimetable;
        event Action ShowTimetablePlan;
        event Action ShowTeachers;
        event Action ShowTeachersTimetable;
        event Action LoadData;
        event Action SaveAsPdf;
        void InitData(TimetableViewInfo info);
        void InitControlsData(IEnumerable<Specialty> specialties, IEnumerable<Teacher> teachers);
        void SetPreLoadState(string message);
        void VisualizeGrid(DataGridViewCommand command);
        IUserView GridOnLoad();
    }
}

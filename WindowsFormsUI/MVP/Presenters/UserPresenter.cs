using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WindowsFormsUI.FormCommands;
using WindowsFormsUI.FormCommands.DataGridCommands;
using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

namespace WindowsFormsUI.MVP.Presenters
{
    public class UserPresenter : BasePresenter<IUserView, User>
    {
        private TimetableViewInfo _timetableView;
        private User _user;
        private ITimetableLoaderService _loaderService;
        public UserPresenter(IApplicationController controller,
            ITimetableLoaderService _timetableLoaderService,
            IUserView view) : base(controller, view)
        {
            _loaderService = _timetableLoaderService;
            View.LoadData += () => LoadViewData();
            View.ShowTeachers += () => View.GridOnLoad().VisualizeGrid(GetTeacherInfoCommand());
            View.ShowTimetablePlan += () => View.GridOnLoad().VisualizeGrid(GetPlanCommand());
            View.ShowTeachersTimetable += () => View.GridOnLoad().VisualizeGrid(GetTeacherTimetableCommand());
            View.ShowTimetable += () => View.GridOnLoad().VisualizeGrid(GetTimetableCommand());
        }

        public void RunAsDialog(TimetableViewInfo timetableViewInfo)
        {
            _timetableView = timetableViewInfo;
            View.ShowDialog();
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
        }

        private void LoadViewData()
        {
            try
            {
                View.IsPreLoading = true;
                View.SetPreLoadState("Загружаем необходимые данные...");
                _loaderService.Load();
                View.InitData(_timetableView ??= _loaderService.GetLastUpdatedViewInfo());
                View.SetPreLoadState("Загружаем список учебного процесса...");
                View.InitControlsData(_loaderService.GetAllSpecialties(), _loaderService.GetNamedTeachers());
                View.IsPreLoading = false;
            }
            catch (Exception e)
            {

            }
        }

        private DataGridViewCommand GetTeacherInfoCommand()
        {
            return new TeacherInfoCommand(View.SelectedTeacherAbout is null
                ? _loaderService.GetNamedTeachers()
                : new List<Teacher> { View.SelectedTeacherAbout });
        }

        private DataGridViewCommand GetPlanCommand()
        {
            if (View.SelectedSpecialtyForPlan is null) return null;
            return new TimetablePlanCommand(_loaderService.GetPlanBySpecialty(View.SelectedSpecialtyForPlan));
        }

        private DataGridViewCommand GetTimetableCommand()
        {
            return new TimetableCommand(
                View.SelectedGroupForTimetable is null
                ? View.TimetableViewInfo.TimetableView.Select(x => x.Group).Distinct().ToList()
                : new List<Group>() { View.SelectedGroupForTimetable },
                View.TimetableViewInfo);
        }

        private DataGridViewCommand GetTeacherTimetableCommand()
        {
            if (View.SelectedTeacherForTimetable is null) return null;
            return new TeacherTimetableCommand(View.SelectedTeacherForTimetable, View.TimetableViewInfo);
        }
    }
}

using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsUI.Services
{
    public class TimetableLoaderService : ITimetableLoaderService
    {
        private ITimetableViewData _viewData;
        public void Load()
        {
            _viewData = new TimetableViewData(
                    new LessonContext(),
                    new SpecialtyContext(),
                    new PlanContext(),
                    new TimetableViewContext());
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return _viewData.Specialties.GetAll();
        }

        public IEnumerable<Teacher> GetNamedTeachers()
        {
            return _viewData.TeacherSubject.GetNamedTeachers();
        }

        public TimetableViewInfo GetLastUpdatedViewInfo()
        {
            return _viewData.TimetableView.GetLastUpdated();
        }

        public PlanInformation GetPlanBySpecialty(Specialty specialty)
        {
            return _viewData.PlansInformation.GetPlanBySpecialty(specialty.Id);
        }
    }
}

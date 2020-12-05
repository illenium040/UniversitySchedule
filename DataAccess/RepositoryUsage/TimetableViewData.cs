using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryImplementation;
using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryUsage
{
    public class TimetableViewData : ITimetableViewData
    {
        public ILessonsRepository TeacherSubject { get; private set; }
        public ISpecialtyRepository Specialties { get; private set; }
        public IPlanInformationRepository PlansInformation { get; private set; }
        public ITimetableViewRepository TimetableView { get; private set; }

        private readonly LessonContext _lessonsContext;
        private readonly SpecialtyContext _specialtiesContext;
        private readonly PlanContext _planContext;
        private readonly TimetableViewContext _viewContext;
        public TimetableViewData(
            LessonContext lessonsContext,
            SpecialtyContext specialtiesContext,
            PlanContext planContext,
            TimetableViewContext viewContext)
        {
            _lessonsContext = lessonsContext;
            _specialtiesContext = specialtiesContext;
            _planContext = planContext;
            _viewContext = viewContext;
            TeacherSubject = new LessonsRepository(_lessonsContext);
            Specialties = new SpecialtiesRepository(_specialtiesContext);
            PlansInformation = new PlanInformationRepository(_planContext);
            TimetableView = new TimetableViewRepository(_viewContext);
        }

        public void Dispose()
        {
            _lessonsContext.Dispose();
            _specialtiesContext.Dispose();
            _planContext.Dispose();
            _viewContext.Dispose();
        }

        public int Complete()
        {
            return _viewContext.SaveChanges();
        }
    }
}

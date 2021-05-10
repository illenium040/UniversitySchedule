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

        public LessonContext LessonsContext { get; }
        public SpecialtyContext SpecialtiesContext { get; }
        public PlanContext PlanContext { get; }
        public TimetableViewContext ViewContext { get; }
        public TimetableViewData(
            LessonContext lessonsContext,
            SpecialtyContext specialtiesContext,
            PlanContext planContext,
            TimetableViewContext viewContext)
        {
            LessonsContext = lessonsContext;
            SpecialtiesContext = specialtiesContext;
            PlanContext = planContext;
            ViewContext = viewContext;
            TeacherSubject = new LessonsRepository(LessonsContext);
            Specialties = new SpecialtiesRepository(SpecialtiesContext);
            PlansInformation = new PlanInformationRepository(PlanContext);
            TimetableView = new TimetableViewRepository(ViewContext);
        }

        public void Dispose()
        {
            LessonsContext.Dispose();
            SpecialtiesContext.Dispose();
            PlanContext.Dispose();
            ViewContext.Dispose();
        }

        public int Complete()
        {
            PlanContext.SaveChanges();
            LessonsContext.SaveChanges();
            SpecialtiesContext.SaveChanges();
            return ViewContext.SaveChanges();
        }
    }
}

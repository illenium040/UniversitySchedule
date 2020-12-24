using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public abstract class TimetableDataContainer : IDisposable
    {
        protected ITimetableViewData ViewData;
        public SemestersParts SemestersPart { get; }
        public IEnumerable<TeacherSubject> TeacherSubjects { get; protected set; }
        public IEnumerable<Specialty> Specialties { get; protected set; }
        public IEnumerable<PlanInformation> PlansInformation { get; protected set; }
        public ITimetableViewRepository TimetableView { get; protected set; }

        public TimetableDataContainer Init(ITimetableViewData data)
        {
            ViewData = data;
            InitTeacherSubjects();
            InitSpecialties();
            InitPlansInformation();
            InitView();
            return this;
        }

        protected abstract void InitTeacherSubjects();
        protected abstract void InitSpecialties();
        protected abstract void InitPlansInformation();
        protected abstract void InitView();

        public virtual void SaveChanges()
        {
            ViewData.Complete();
        }

        public void Dispose()
        {
            ViewData.Dispose();
        }
    }
}

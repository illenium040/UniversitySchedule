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
        protected ITimetableViewData Data;
        public SemestersParts SemestersPart { get; }
        public IEnumerable<TeacherSubject> TeacherSubjects { get; protected set; }
        public IEnumerable<Specialty> Specialties { get; protected set; }
        public IEnumerable<PlanInformation> PlansInformation { get; protected set; }
        public ITimetableViewRepository TimetableView { get; protected set; }
        public TimetableDataContainer()
        {
            SemestersPart = TimetableDefaultSettings.SemestersPart;
        }

        public TimetableDataContainer Init(ITimetableViewData data)
        {
            Data = data;
            InitTeacherSubjects(data);
            InitSpecialties(data);
            InitPlansInformation(data);
            InitView(data);
            return this;
        }

        protected abstract void InitTeacherSubjects(ITimetableViewData data);
        protected abstract void InitSpecialties(ITimetableViewData data);
        protected abstract void InitPlansInformation(ITimetableViewData data);
        protected abstract void InitView(ITimetableViewData data);

        public virtual void SaveChanges()
        {
            Data.Complete();
        }

        public void Dispose()
        {
            Data.Dispose();
        }
    }
}

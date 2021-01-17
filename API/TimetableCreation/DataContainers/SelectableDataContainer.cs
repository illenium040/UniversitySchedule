using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.TimetableCreation;
using DataAccess.Entities;

namespace API.TimetableCreation.DataContainers
{
    public class SelectableTimetableData
    {
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<PlanInformation> Plans { get; set; }
    }

    public class SelectableDataContainer : TimetableDataContainer
    {
        private SelectableTimetableData _data;
        public SelectableDataContainer(SelectableTimetableData data)
        {
            _data = data;
        }

        protected override void InitPlansInformation()
        {
            PlansInformation = _data.Plans;
        }

        protected override void InitSpecialties()
        {
            Specialties = _data.Specialties;
        }

        protected override void InitTeacherSubjects()
        {
            TeacherSubjects = ViewData.TeacherSubject.GetWithNamedTeachers();
        }

        protected override void InitView()
        {
            TimetableView = ViewData.TimetableView;
        }
    }
}

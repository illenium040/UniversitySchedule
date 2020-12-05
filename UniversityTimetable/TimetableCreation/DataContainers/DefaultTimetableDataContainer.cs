using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

namespace UniversityTimetableGenerator.TimetableCreation.DataContainers
{
    public class DefaultTimetableDataContainer : TimetableDataContainer
    {
        protected override void InitPlansInformation(ITimetableViewData data)
        {
            TeacherSubjects = data.TeacherSubject.GetWithNamedTeachers();
        }

        protected override void InitSpecialties(ITimetableViewData data)
        {
            Specialties = data.Specialties.GetAll();
        }

        protected override void InitTeacherSubjects(ITimetableViewData data)
        {
            PlansInformation = data.PlansInformation.GetAllWithoutPractice().ToList();
        }

        protected override void InitView(ITimetableViewData data)
        {
            TimetableView = data.TimetableView;
        }
    }
}

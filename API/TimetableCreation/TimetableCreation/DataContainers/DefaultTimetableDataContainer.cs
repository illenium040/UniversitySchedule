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
        protected override void InitPlansInformation()
        {
            TeacherSubjects = ViewData.TeacherSubject.GetWithNamedTeachers();
        }

        protected override void InitSpecialties()
        {
            Specialties = ViewData.Specialties.GetAll();
        }

        protected override void InitTeacherSubjects()
        {
            PlansInformation = ViewData.PlansInformation.GetAllWithoutPractice().ToList();
        }

        protected override void InitView()
        {
            TimetableView = ViewData.TimetableView;
        }
    }
}

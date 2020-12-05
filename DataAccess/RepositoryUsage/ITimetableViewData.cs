using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryUsage
{
    public interface ITimetableViewData : IRepositoryUsage
    {
        ILessonsRepository TeacherSubject { get; }
        ISpecialtyRepository Specialties { get; }
        IPlanInformationRepository PlansInformation { get; }
        ITimetableViewRepository TimetableView { get; }
    }
}

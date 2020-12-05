using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryInterfaces
{
    public interface IPlanInformationRepository : IRepository<PlanInformation>
    {
        IEnumerable<PlanInformation> GetAllWithoutPractice();
        PlanInformation GetPlanInformationBySpecialty(int specialtyId);
    }
}

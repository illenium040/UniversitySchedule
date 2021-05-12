using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryInterfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        public void RemoveGroup(Group g);
        public void AddGroup(Group g);
        public void UpdateGroup(Group g);

    }
}

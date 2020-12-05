using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryUsage
{
    public interface IUserAuthorization : IRepositoryUsage
    {
        public IUserRepository UserRepository { get; }
    }
}

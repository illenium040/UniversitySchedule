using DataAccess.Contexts;
using DataAccess.Repositories.RepositoryImplementation;
using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryUsage
{
    public class UserAuthorization : IUserAuthorization
    {
        public IUserRepository UserRepository { get; private set; }

        private readonly UserContext _userContext;
        public UserAuthorization(UserContext context)
        {
            _userContext = context;
            UserRepository = new UserRepository(_userContext);
        }

        public int Complete()
        {
            return _userContext.SaveChanges();
        }

        public void Dispose()
        {
            _userContext.Dispose();
        }
    }
}

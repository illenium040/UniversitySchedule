using DataAccess;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI.Services
{
    public class AuthService : IAuthService
    {
        private UserAuthorization _userAuth;
        public Task<User> Auth(string login, string password)
        {
            _userAuth ??= new UserAuthorization(new UserContext());
            return Task.FromResult(_userAuth.UserRepository.GetUser(login, password));
        }
    }
}

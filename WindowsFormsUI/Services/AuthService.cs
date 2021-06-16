using DataAccess;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<User> FindUser(string login)
            => Task.FromResult((_userAuth ??= new UserAuthorization(new UserContext())).UserRepository.Find(x => x.Login == login).FirstOrDefault());
        

        public Task<User> RegisterAdmin(string login, string password)
        {
            _userAuth ??= new UserAuthorization(new UserContext());
            _userAuth.UserRepository.AddAdmin(login, password);
            _userAuth.Complete();
            return Task.FromResult(_userAuth.UserRepository.GetUser(login, password));
        }

        public Task<User> RegisterUser(string login, string password)
        {
            _userAuth ??= new UserAuthorization(new UserContext());
            _userAuth.UserRepository.AddUser(login, password);
            _userAuth.Complete();
            return Task.FromResult(_userAuth.UserRepository.GetUser(login, password));
        }
    }
}

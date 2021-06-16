using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryImplementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserContext UserContext { get { return Context as UserContext; } }
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetUser(string login, string password)
        {
            if (!ContainsUser(login))
                throw new UnauthorizedAccessException("There isn't such user exists");
            var user = UserContext.Users.AsNoTracking()
                .First(x => x.Login == login);
            if(!SecurityHelper.IsValidPassword(user.Password, password))
                throw new UnauthorizedAccessException("Incorrect login or password");
            return user;
        }

        public void AddAdmin(string login, string password)
        {
            UserContext.Users.Add(new User()
            {
                Id = SecurityHelper.GetGuidString(),
                Login = login,
                Password = SecurityHelper.GetHashedPassword(password),
                IsAdmin = true
            });
        }

        public void AddUser(string login, string password)
        {
            UserContext.Users.Add(new User()
            {
                Id = SecurityHelper.GetGuidString(),
                Login = login,
                Password = SecurityHelper.GetHashedPassword(password),
                IsAdmin = false
            });
        }

        public bool ContainsUser(string login)
        {
            return UserContext.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Login == login) == default ? false : true;
        }
    }
}

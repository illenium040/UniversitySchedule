using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public bool ContainsUser(string login);
        public User GetUser(string login, string password);
        public void AddAdmin(string login, string password);
        public void AddUser(string login, string password);
    }
}

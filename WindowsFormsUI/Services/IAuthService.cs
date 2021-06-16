using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI.Services
{
    public interface IAuthService
    {
        Task<User> Auth(string login, string password);
        Task<User> FindUser(string login);
        Task<User> RegisterUser(string login, string password);
        Task<User> RegisterAdmin(string login, string password);
    }
}

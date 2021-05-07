using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otgul.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
        User GetUserFromId(int userId);
        User GetUserFromLogin(string login);
        Role GetUserRoleFromId(int userId);
        IEnumerable<UserRight> GetUserRightsFromId(int userId);
        void UpdateUser(User user);
        void RemoveUser(int userId);
        IEnumerable<User> GetActiveUser();
        User GetUserFromLogoPass(string login, string password);

    }
}

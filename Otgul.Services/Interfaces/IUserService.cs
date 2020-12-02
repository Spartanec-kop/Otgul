using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUserFromId(int userId);
        Role GetUserRoleFromId(int userId);
        IEnumerable<UserRights> GetUserRightsFromId(int userId);
        void UpdateUse(User user);
        void RemoveUser(int userId);
        IEnumerable<User> GetActiveUser();

    }
}

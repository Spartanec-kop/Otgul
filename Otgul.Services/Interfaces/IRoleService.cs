using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(Role role);
        IEnumerable<Role> GetAllActiveRole();
        Role GetRoleFromId(int roleId);
        void UpdateRole(Role role);
        void RemoveRole(int roleId);
    }
}

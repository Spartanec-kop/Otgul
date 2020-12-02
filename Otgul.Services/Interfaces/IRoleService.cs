using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IRoleService
    {
        void CreateNewRole(IRoleService role);
        IEnumerable<Role> GetAllActiveRole();
        void EditRole(Role role);
        void RemoveRole(int roleId);
    }
}

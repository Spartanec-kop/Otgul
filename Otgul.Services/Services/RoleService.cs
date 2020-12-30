using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDataBaseRepository<Role> _roleRepository;

        public RoleService(IDataBaseRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public void CreateRole(Role role)
        {
            _roleRepository.Create(role);
            _roleRepository.Save();
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.Update(role);
            _roleRepository.Save();
        }

        public IEnumerable<Role> GetAllActiveRole()
        {
           return _roleRepository.Find(f => !f.IsDeleted);
        }

        public Role GetRoleFromId(int roleId)
        {
            return _roleRepository.GetId(roleId);
        }

        public void RemoveRole(int roleId)
        {
            Role role = _roleRepository.GetId(roleId);
            if (role != null)
            {
                role.IsDeleted = true;
                _roleRepository.Update(role);
                _roleRepository.Save();
            }
        }
    }
}

using Otgul.DataBase.Repository.Repository;
using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IDataBaseRepository<User> _userRepository;
        public UserService (IDataBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            _userRepository.Create(user);
            _userRepository.Save();
        }

        public IEnumerable<User> GetActiveUser()
        {
            return _userRepository.Find(f => !f.IsDeleted);
        }

        public User GetUserFromId(int userId)
        {
            return _userRepository.GetId(userId);
        }

        public Role GetUserRoleFromId(int userId)
        {
            return _userRepository.GetId(userId).Role;
        }

        public IEnumerable<UserRights> GetUserRightsFromId(int userId)
        {
            return _userRepository.GetId(userId).UserRights;
        }
        public void RemoveUser(int userId)
        {
            User user = _userRepository.GetId(userId);
            if (user != null)
            {
                user.IsDeleted = true;
                _userRepository.Update(user);
            }
        }

        public void UpdateUse(User user)
        {
            _userRepository.Update(user);
        }
    }
}

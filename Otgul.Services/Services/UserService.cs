using Otgul.DataBase.Repository.Repository;
using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public User GetUserFromLogin(string login)
        {
            return _userRepository.Find(f => f.Login == login).FirstOrDefault();
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
        public User GetUserFromLogoPass(string login, string password)
        {
            IEnumerable<User> users = _userRepository.Find(r => r.Login == login && r.Password == password).ToList();
            if (users != null && users.Count() > 0)
            {
                return users.First();
            } else
            {
                return null;
            }
                     
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}

using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class RightService : IRightService
    {
        private readonly IDataBaseRepository<Right> _rightRepository;

        public RightService(IDataBaseRepository<Right> rightRepository)
        {
            _rightRepository = rightRepository;
        }
        public void CreateRight(Right right)
        {
            _rightRepository.Create(right);
            _rightRepository.Save();
        }

        public void UpdateRight(Right right)
        {
            _rightRepository.Update(right);
            _rightRepository.Save();
        }

        public IEnumerable<Right> GetAllRight()
        {
           return _rightRepository.GetAll();
        }

        public Right GetRightFromId(int rightId)
        {
            return _rightRepository.GetId(rightId);
        }

        public void RemoveRight(int rightId)
        {
            Right right = _rightRepository.GetId(rightId);
            if (right != null)
            {
                _rightRepository.Delete(rightId);
                _rightRepository.Save();
            }
        }
    }
}

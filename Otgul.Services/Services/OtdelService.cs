using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class OtdelService : IOtdelService
    {
        private readonly IDataBaseRepository<Otdel> _otdelRepository;

        public OtdelService(IDataBaseRepository<Otdel> otdelRepository)
        {
            _otdelRepository = otdelRepository;
        }
        public void CreateOtdel(Otdel otdel)
        {
            _otdelRepository.Create(otdel);
            _otdelRepository.Save();
        }

        public void UpdateOtdel(Otdel otdel)
        {
            _otdelRepository.Update(otdel);
            _otdelRepository.Save();
        }

        public IEnumerable<Otdel> GetAllOtdel()
        {
           return _otdelRepository.GetAll();
        }

        public Otdel GetOtdelFromId(int otdelId)
        {
            return _otdelRepository.GetId(otdelId);
        }

        public void RemoveOtdel(int otdelId)
        {
            Otdel otdel = _otdelRepository.GetId(otdelId);
            if (otdel != null)
            {
                _otdelRepository.Delete(otdelId);
                _otdelRepository.Save();
            }
        }
    }
}

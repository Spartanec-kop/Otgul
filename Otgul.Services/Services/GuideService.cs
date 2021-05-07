using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class GuideService : IGuideService
    {
        private readonly IDataBaseRepository<Guide> _guideRepository;

        public GuideService(IDataBaseRepository<Guide> guideRepository)
        {
            _guideRepository = guideRepository;
        }
        public void CreateGuide(Guide guide)
        {
            _guideRepository.Create(guide);
            _guideRepository.Save();
        }

        public IEnumerable<Guide> GetAllGuide()
        {
            return _guideRepository.GetAll();
        }

        public Guide GetGuideFromId(int guideId)
        {
            return _guideRepository.GetId(guideId);
        }

        public void RemoveGuide(int guideId)
        {
            _guideRepository.Delete(guideId);
        }

        public void UpdateGuide(Guide guide)
        {
            throw new NotImplementedException();
        }
    }
}

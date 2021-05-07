using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IGuideService
    {
        void CreateGuide(Guide guide);
        void RemoveGuide(int guideId);
        void UpdateGuide(Guide guide);
        IEnumerable<Guide> GetAllGuide();
        Guide GetGuideFromId(int guideId);
    }
}

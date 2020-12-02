using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IGuidService
    {
        void CreateGuide(Guide guid);
        void RemoveGuide(int guideId);
        void UpdateGuide(Guide guide);
    }
}

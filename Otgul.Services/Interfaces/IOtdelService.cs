using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IOtdelService
    {
        void CreateOtdel(Otdel otdel);
        IEnumerable<Otdel> GetAllOtdel();
        Otdel GetOtdelFromId(int otdelId);
        void UpdateOtdel(Otdel otdel);
        void RemoveOtdel(int otdelId);
    }
}

using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IOtgulRecordService
    {
        void CreateOtgulRecord(OtgulRecord otgulRecord);
        IEnumerable<OtgulRecord> GetOtgulRecordsFromUser(User user);
        int GetFreeTimeUser(User user);
    }
}

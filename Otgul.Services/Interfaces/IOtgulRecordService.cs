using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IOtgulRecordService
    {
        OtgulRecord CreateOtgulRecord(OtgulRecord otgulRecord);
        OtgulRecord GetOtgulRecordFromId(Int64 id);
        void UpdateOtgulRecord(OtgulRecord otgulRecord);
        IEnumerable<OtgulRecord> GetOtgulRecordsFromUserId(int userId);
        int GetFreeTimeUser(int userId);
        bool CheckExistRecord(OtgulRecord otgulRecord);
    }
}

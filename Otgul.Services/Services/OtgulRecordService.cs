using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otgul.Services.Services
{
    public class OtgulRecordService : IOtgulRecordService
    {
        private readonly IDataBaseRepository<OtgulRecord> _otgulRecordRepository;

        public OtgulRecordService (IDataBaseRepository<OtgulRecord> otgulRecordRepository)
        {
            _otgulRecordRepository = otgulRecordRepository;
        }

        public bool CheckExistRecord(OtgulRecord otgulRecord)
        {
            IEnumerable<OtgulRecord> tmpOtgulRecord = _otgulRecordRepository.Find(record => 
                record.User.Id == otgulRecord.User.Id && 
                record.Action == otgulRecord.Action &&
                record.MinutCount == otgulRecord.MinutCount &&
                record.Date == otgulRecord.Date &&
                record.Guide.Id == otgulRecord.Guide.Id
            );

            if (tmpOtgulRecord == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public OtgulRecord CreateOtgulRecord(OtgulRecord otgulRecord)
        {
            OtgulRecord newOtgulRecord = _otgulRecordRepository.Create(otgulRecord);
            _otgulRecordRepository.Save();
            return newOtgulRecord;
        }

        public void UpdateOtgulRecord(OtgulRecord otgulRecord)
        {
            _otgulRecordRepository.Update(otgulRecord);
            _otgulRecordRepository.Save();
        }

        public int GetFreeTimeUser(int userId)
        {
            return _otgulRecordRepository.Find(f => f.User.Id == userId, false).Select(s => new
            {
               minutes = s.Action ? s.MinutCount * 1 : s.MinutCount * -1
            }).Sum(s=> s.minutes);
        }

        public OtgulRecord GetOtgulRecordFromId(Int64 id)
        {
            return _otgulRecordRepository.GetId(id);
        }

        public IEnumerable<OtgulRecord> GetOtgulRecordsFromUserId(int userId)
        {
            return _otgulRecordRepository.Find(f => f.User.Id == userId);
        }
    }
}

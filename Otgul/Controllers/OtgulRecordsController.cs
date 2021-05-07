using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otgul.Api.ViewModel;
using Otgul.Models;
using Otgul.Services.Interfaces;
using Otgul.Api;

namespace Otgul.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OtgulRecordController : Controller
    {
        private readonly IOtgulRecordService _otgulRecordService;
        private readonly Mapper _mapper;

        public OtgulRecordController(IOtgulRecordService otgulRecordService, Mapper mapper)
        {
            _otgulRecordService = otgulRecordService;
            _mapper = mapper;
        }

        // GET: api/OtgulRecords/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ViewOtgulRecord>>> GetOtgulRecordsToUser(int userId)
        {
            IEnumerable<OtgulRecord> otgulRecords = _otgulRecordService.GetOtgulRecordsFromUserId(userId);
            if (otgulRecords != null)
            {
                List<ViewOtgulRecord> viewOtgulRecords = otgulRecords.Select(u => _mapper.Map(u)).ToList();
                return viewOtgulRecords;
            }
            else
            {
                return NotFound();
            }

        }

        // GET: api/OtgulRecords/5/freeTime
        [HttpGet("{userId}/freeTime")]
        public async Task<ActionResult<int>> GetFreeTimeToUser(int userId)
        {
            return _otgulRecordService.GetFreeTimeUser(userId);

        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<ViewOtgulRecord>> PostOtgulRecord(int userId, [FromBody] ViewOtgulRecord viewOtgulRecord)
        {
            OtgulRecord otgulRecord = _mapper.Map(viewOtgulRecord);
            if (!_otgulRecordService.CheckExistRecord(otgulRecord))
            {
                
                return _mapper.Map(_otgulRecordService.CreateOtgulRecord(otgulRecord));
            }
            else
            {
                return BadRequest("Такая запись уже существует.");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ViewOtgulRecord>> PutOtgulRecord(int id, [FromBody] ViewOtgulRecord viewOtgulRecord)
        {
            OtgulRecord tmpOtgulRecord = _otgulRecordService.GetOtgulRecordFromId(viewOtgulRecord.Id);
            if (tmpOtgulRecord != null)
            {
                _otgulRecordService.UpdateOtgulRecord(_mapper.Map(viewOtgulRecord));
                return _mapper.Map(_otgulRecordService.GetOtgulRecordFromId(viewOtgulRecord.Id));
            }
            else
            {
                return NotFound();
            }

        }
    }
}

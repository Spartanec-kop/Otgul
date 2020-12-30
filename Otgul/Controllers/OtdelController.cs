using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otgul.Models;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otgul.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OtdelController : ControllerBase
    {
        private readonly IOtdelService _otdelService;

        public OtdelController(IOtdelService otdelService)
        {
            _otdelService = otdelService;
        }

        // GET: api/<OtdelController>
        [HttpGet]
        public IEnumerable<Otdel> Get()
        {
            return _otdelService.GetAllOtdel();
        }

        // GET api/<OtdelController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<OtdelController>
        [HttpPost]
        public void Post([FromBody] Otdel otdel)
        {
            _otdelService.CreateOtdel(otdel);
        }

        // PUT api/<OtdelController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Otdel otdel)
        {
            _otdelService.UpdateOtdel(otdel);
        }

        // DELETE api/<OtdelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _otdelService.RemoveOtdel(id);
        }
    }
}

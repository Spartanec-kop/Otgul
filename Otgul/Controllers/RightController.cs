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
    public class RightController : ControllerBase
    {
        private readonly IRightService _rightService;

        public RightController(IRightService rightService)
        {
            _rightService = rightService;
        }

        // GET: api/<RightController>
        [HttpGet]
        public IEnumerable<Right> Get()
        {
            return _rightService.GetAllRight();
        }

        // GET api/<RightController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<RightController>
        [HttpPost]
        public void Post([FromBody] Right right)
        {
            _rightService.CreateRight(right);
        }

        // PUT api/<RightController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Right right)
        {
            _rightService.UpdateRight(right);
        }

        // DELETE api/<RightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rightService.RemoveRight(id);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otgul.Api;
using Otgul.Api.ViewModel;
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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly Mapper _mapper;

        public RoleController(Mapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Role> roles = _roleService.GetAllActiveRole();
            return Json(roles.Select(r => _mapper.Map(r)));
        }

        // GET api/<RoleController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] Role role)
        {
            _roleService.CreateRole(role);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Role role)
        {
            _roleService.UpdateRole(role);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.RemoveRole(id);
        }
    }
}

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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _departmentService.GetAllDepartment();
        }

        // GET api/<DepartmentController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _departmentService.CreateDepartment(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Department department)
        {
            _departmentService.UpdateDepartment(department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentService.RemoveDepartment(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;

namespace WebAPI {
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeInformationController : Controller
    {
        private readonly IEmployeeInformationRepository _repo;

        public EmployeeInformationController(IEmployeeInformationRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: api/<EmployeeInformationController>/all
        [HttpGet("All")]
        public IActionResult GetAllEmployeeInformation()
        {
            return Ok(_repo.GetAll());
        }

        // GET: api/<EmployeeInformationController>/5
        [HttpGet("{p_id}")]
        public IActionResult GetEmployeeInformationById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }

        // POST api/EmployeeInformation/add
        [HttpPost("add")]
        public IActionResult AddEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Create(p_info);
            _repo.Save();
            return Created("api/EmployeeInformation/add", p_info);
        }

        // PUT api/EmployeeInformation/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Update(p_info);
            _repo.Save();
            return Ok();
        }

        // DELETE api/EmployeeInformation/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Delete(p_info);
            _repo.Save();
            return Ok();
        }
    }
}
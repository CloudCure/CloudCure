using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using System;
using Serilog;

namespace WebAPI {
    [Route("employee")]
    [ApiController]
    public class EmployeeInformationController : Controller
    {
        private readonly IEmployeeInformationRepository _repo;

        public EmployeeInformationController(IEmployeeInformationRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: employee/all
        [HttpGet("All")]
        public IActionResult GetAllEmployeeInformation()
        {
            return Ok(_repo.GetAll());
        }

        // GET: employee/5
        [HttpGet("{p_id}")]
        public IActionResult GetEmployeeInformationById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }
        
        // GET: employee/verify/{p_email}
        [HttpGet("Verify/{p_email}")]
        public IActionResult VerifyUser(string p_email)
        {
            try
            {
                return Ok(_repo.VerifyEmail(p_email));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a current user");
            }
        }

        // POST employee/add
        [HttpPost("add")]
        public IActionResult AddEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Create(p_info);
            _repo.Save();
            return Created("api/EmployeeInformation/add", p_info);
        }

        // PUT employee/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Update(p_info);
            _repo.Save();
            return Ok();
        }

        // DELETE employee/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployeeInformation([FromBody] EmployeeInformation p_info)
        {
            _repo.Delete(p_info);
            _repo.Save();
            return Ok();
        }
    }
}



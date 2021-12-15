using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using System;
using Serilog;

namespace WebAPI {
    [Route("Employee")]
    [ApiController]
    public class EmployeeInformationController : Controller
    {
        //Dependency Injection
        private readonly IEmployeeInformationRepository _repo;

        public EmployeeInformationController(IEmployeeInformationRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: employee/all
        [HttpGet("All")] //("All") Will give a case-insensitive endpoint that ends with All
        public IActionResult GetAllEmployeeInformation()
        {
            return Ok(_repo.GetAll());
        }

        // GET: employee/{p_id}
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
            return Created("employee/add", p_info);
        }

        // PUT employee/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateEmployeeInformation(int id,[FromBody] EmployeeInformation p_info)
        {
            var item = _repo.GetByPrimaryKey(id);
            item.WorkEmail = p_info.WorkEmail;
            item.Specialization = p_info.Specialization;
            item.StartDate = p_info.StartDate;
            item.RoomNumber = p_info.RoomNumber;
            item.EducationDegree = p_info.EducationDegree;
            _repo.Update(item);
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



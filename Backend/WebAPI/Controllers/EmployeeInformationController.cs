using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;

namespace WebAPI
{
    [Route("Employee")]
    [ApiController]
    public class EmployeeInformationController : Controller
    {
        //Dependency Injection
        private readonly IEmployeeInformationRepository _repo;

        public EmployeeInformationController(IEmployeeInformationRepository p_repo) { _repo = p_repo; }

        // GET: Employee/Get/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: Employee/Get/5
        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int p_id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(p_id));
            }
            catch (Exception)
            {
                return BadRequest("Not a valid ID");
            }
        }

        // GET: Employee/Verify/{p_email}
        [HttpGet("Verify/{p_email}")]
        public IActionResult VerifyUser(string p_email)
        {
            try
            {
                return Ok(_repo.VerifyEmail(p_email));
            }
            catch (Exception)
            {
                return BadRequest("Not a current user");
            }
        }

        // POST Employee/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] EmployeeInformation p_employee)
        {
            try
            {
                _repo.Create(p_employee);
                _repo.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Invalid input.");
            }
        }

        // DELETE employee/delete/{id}
        [HttpDelete("Delete/{p_id}")]
        public IActionResult Delete(int p_id)
        {
            try
            {
                var topic = _repo.GetByPrimaryKey(p_id);
                _repo.Delete(topic);
                _repo.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Not a valid Id");
            }
        }

        // PUT Employee/Update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeInformation p_employee)
        {
            try
            {
                p_employee.Id = id;
                _repo.Update(p_employee);
                _repo.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Input");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace WebAPI
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeInformationController : ControllerBase
    {
        private readonly IEmployeeInformationRepository employeeRepository;

        public EmployeeInformationController(IEmployeeInformationRepository context)
        {
            employeeRepository = context;
        }

        [HttpGet("All")]
        public IActionResult GetAllUsers()
        {

            return null;
        }


        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {

            return Ok(employeeRepository.GetByPrimaryKey(id));

        }


        [HttpGet("Verify/{email}")]
        public IActionResult VerifyUser(string email)
        {
            return null;
        }



        [HttpPost("Add")]
        public IActionResult AddEmployeeInformation([FromBody] EmployeeInformation p_user)
        {
            employeeRepository.Create(p_user);
            employeeRepository.Save();
            return Created("EmployeeInformation/Add", p_user);

        }


        [HttpPut("Update")]
        public IActionResult UpdateUser(int id, [FromBody] EmployeeInformation p_user)
        {
            var item = employeeRepository.GetByPrimaryKey(id);
            employeeRepository.Update(p_user);
            employeeRepository.Save();
            return null;
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var item = employeeRepository.GetByPrimaryKey(id);
            employeeRepository.Delete(item);
            employeeRepository.Save();
            return Ok();

        }
    }
}


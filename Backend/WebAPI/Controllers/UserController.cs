using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace WebAPI
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository context)
        {
            userRepository = context;
        }
        // GET: api/<User>/all
        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {

            return Ok(userRepository.GetAll());
        }

        // GET: api/<User>/GetUserById/ {id number}
        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {

            return Ok(userRepository.GetByPrimaryKey(id));
        }


        // Post: api/<User>/Add
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User p_user)
        {
            userRepository.Create(p_user);
            userRepository.Save();
            return Created("User/Add", p_user);

        }

        // PUT api/user/update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User p_user)
        {
            var item = userRepository.GetByPrimaryKey(id);
            item.FirstName = p_user.FirstName;
            item.LastName = p_user.LastName;
            item.DateOfBirth = p_user.DateOfBirth;
            item.PhoneNumber = p_user.PhoneNumber;
            item.Address = p_user.Address;
            item.EmergencyName = p_user.EmergencyName;
            item.EmergencyContactPhone = p_user.EmergencyContactPhone;
            item.RoleId = p_user.RoleId;
            userRepository.Update(item);
            userRepository.Save();
            return null;
        }

        // DELETE api/User/delete/{id}
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var item = userRepository.GetByPrimaryKey(id);
            userRepository.Delete(item);
            userRepository.Save();
            return Ok();

        }
    }
}

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
        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {

            return Ok(userRepository.GetAll());
        }

        
        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {

            return Ok(userRepository.GetByPrimaryKey(id));
        }


        // POST api/<UserController>
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User p_user)
        {
            userRepository.Create(p_user);
            userRepository.Save();
            return Created("User/Add", p_user);

        }


        [HttpPut("Update/{id}")]
        public IActionResult UpdateUser(int id,[FromBody] User p_user)
        {
            var item = userRepository.GetByPrimaryKey(id);
            userRepository.Update(p_user);
            userRepository.Save();
            return null;
        }

        // DELETE api/<UserController>/5
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

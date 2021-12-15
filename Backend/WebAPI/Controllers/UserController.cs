using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using System;
using Serilog;

namespace WebAPI
{

    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Dependency Injection
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository context)
        {
            userRepository = context;
        }
        // GET: user/all
        [HttpGet("All")] //("All") Will give a case-insensitive endpoint that ends with All
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(userRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(userRepository.GetByPrimaryKey(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
            
        }


        // Post: user/Add
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] User p_user)
        {
            try
            {
                userRepository.Create(p_user);
                userRepository.Save();
                return Created("User/Add", p_user);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid create form.");
            }      

        }

        // PUT user/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User p_user)
        {
            try
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
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid put request.");
            }     
        }

        // DELETE User/delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
            var item = userRepository.GetByPrimaryKey(id);
            userRepository.Delete(item);
            userRepository.Save();
            return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid delete request.");
            }

        }
    }
}

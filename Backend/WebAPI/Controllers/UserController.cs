using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Dependency injection for CovidRepository
        private readonly IUserRepository _repo;

        public UserController(IUserRepository p_repo){_repo = p_repo;}
        
        // GET: api/User/all
        [HttpGet("All")]
        public IActionResult GetAll(){   
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: api/User/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }


        // Post: api/User/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] User p_user){
            try{
                _repo.Create(p_user);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid add request.");
            }
        }

        // PUT api/user/update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User p_user){
            var item = _repo.GetByPrimaryKey(id);
            item.FirstName = p_user.FirstName;
            item.LastName = p_user.LastName;
            item.DateOfBirth = p_user.DateOfBirth;
            item.PhoneNumber = p_user.PhoneNumber;
            item.Address = p_user.Address;
            item.EmergencyName = p_user.EmergencyName;
            item.EmergencyContactPhone = p_user.EmergencyContactPhone;
            item.RoleId = p_user.RoleId;
            _repo.Update(item);
            _repo.Save();
            return null;
        }

        // DELETE api/User/delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id){
            try{
                var item = _repo.GetByPrimaryKey(id);
                _repo.Delete(item);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }
    }
}

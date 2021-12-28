using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Dependency Injection
        private readonly IUserRepository _repo;

        public UserController(IUserRepository p_repo) { _repo = p_repo; }

        // GET: User/Get/all
        [HttpGet("Get/All")]//Get all users
        public IActionResult GetAll()
        {
            try
            {
                List<User> u = _repo.GetAll().ToList();
                if (u.Count == 0)
                    throw new Exception("No data found");//If null, will return "no data found"
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all users request.");//Logs all bad requests into separate file
            }
        }

        // GET: User/Get/{id}
        [HttpGet("Get/{id}")]//Gets user by Id
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new Exception("Invalid Id");
                return Ok(_repo.GetUserById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get user by id request.");
            }
        }

        // Post: User/Add
        [HttpPost("Add")]//Adds new user info
        public IActionResult Add([FromBody] User p_user)
        {
            try
            {
                if (p_user == null)
                    throw new Exception("Invalid data!");
                _repo.Create(p_user);
                _repo.Save();
                return Created("User/Add", p_user);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid add request.");
            }
        }

        // DELETE: User/Delete/{id}
        [HttpDelete("Delete/{id}")]//Deletes user by Id
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _repo.GetById(id);
                if(item == null)
                    throw new Exception("Delete failed!");
                _repo.Delete(item);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }

        // PUT: User/Update/{id}
        [HttpPut("Update/{id}")]//Udates user by Id
        public IActionResult Update(int id, [FromBody] User p_user)
        {
            try
            {
                p_user.Id = id;
                _repo.Update(p_user);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }
    }
}
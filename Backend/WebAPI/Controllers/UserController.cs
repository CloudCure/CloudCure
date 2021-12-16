using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository p_repo) { _repo = p_repo; }

        // GET: User/all
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: User/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int p_id)
        {
            try
            {
                return Ok(_repo.GetById(p_id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        // Post: User/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] User p_user)
        {
            try
            {
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
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _repo.GetById(id);
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
        [HttpPut("Update/{id}")]
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
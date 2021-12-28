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
    public class RoleController : ControllerBase
    {
        //Dependency injection
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository p_repo) { _repo = p_repo; }

        // GET: Role/Get/All
        [HttpGet("Get/All")]//Get all list of roles
        public IActionResult GetAll()
        {
            try
            {
                List<Role> r = _repo.GetAll().ToList();
                if (r.Count == 0)
                    throw new Exception("No data found");//If returns null, prints "no data found"
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");//Logs all bad requests into separate file
            }
        }

        // GET: Role/Get/{Id}
        [HttpGet("Get/{id}")]//Get role by Id
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new Exception("Invalid Id");
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        // POST: Role/Add
        [HttpPost("Add")]//Adds new role info
        public IActionResult Add([FromBody] Role p_role)
        {
            try
            {
                if (p_role == null)
                    throw new Exception("Invalid data!");
                _repo.Create(p_role);
                _repo.Save();
                return Created("Role/Add", p_role);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        // PUT: Role/Update/{Id}
        [HttpPut("Update/{id}")]//Updates role info by Id
        public IActionResult Update(int id, [FromBody] Role p_role)
        {
            try
            {
                p_role.Id = id;
                _repo.Update(p_role);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        // DELETE: Role/Delete/{Id}
        [HttpDelete("Delete/{id}")]//Deletes role info by Id
        public IActionResult Delete([FromBody] Role p_role)
        {
            try
            {
                if (p_role == null)
                    throw new Exception("Delete failed!");
                _repo.Delete(p_role);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }
    }
}
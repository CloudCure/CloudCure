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
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                List<Role> r = _repo.GetAll().ToList();
                if (r.Count == 0)
                    throw new Exception("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: Role/Get/Id
        [HttpGet("Get/{id}")]
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
        [HttpPost("Add")]
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

        // PUT: Role/Update/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Role p_role)
        {
            try
            {
                if (_repo.GetById(id) == null || p_role == null)
                    throw new Exception("Update failed!");
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

        // DELETE: Role/Delete/Id
        [HttpDelete("Delete/{id}")]
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
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

    [Route("Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Dependency injection
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: Role/All
        [HttpGet("All")] //("All") Will give an endpoint that ends with All
        public IActionResult GetAllRole()
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

        // GET Role/Id
        [HttpGet("{p_id}")] //("ID") Will give an endpoint that ends with Id
        public IActionResult GetRoleById(int p_id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(p_id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid ID");
            }
        }
        // POST Role/Add
        [HttpPost("add")]//("Add") Will give an endpoint that ends with Add
        public IActionResult AddRole([FromBody] Role p_role)
        {
            try
            {
            _repo.Create(p_role);
            _repo.Save();
            return Created("api/covid/add", p_role);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Input");
            }
        }


        // PUT Role/Edit
        [HttpPut("edit/{id}")]//("ID") Will give an endpoint that ends with Id
        public IActionResult UpdateRole([FromBody] Role p_role)
        {
            try
            {
                _repo.Update(p_role);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Invalid ID");
            }
        }

        // DELETE Role/Id
        [HttpDelete("delete/{id}")]//("ID") Will give an endpoint that ends with Id
        public IActionResult DeleteRole([FromBody] Role p_role)
        {
            try
            {
                _repo.Delete(p_role);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Invalid ID");
            }
        }
    }
}
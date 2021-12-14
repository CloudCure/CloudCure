using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;

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
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllRole()
        {
            return Ok(_repo.GetAll());
        }

        // GET Role/Id
        [HttpGet("{p_id}")]
        public IActionResult GetRoleById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }

        // POST Role/Add
        [HttpPost("add")]
        public IActionResult AddRole([FromBody] Role p_role)
        {
            _repo.Create(p_role);
            _repo.Save();
            return Created("Role/add", p_role);
        }


        // PUT Role/Edit
        [HttpPut("edit/{id}")]
        public IActionResult UpdateRole([FromBody] Role p_role)
        {
            _repo.Update(p_role);
            _repo.Save();
            return Ok();
        }

        // DELETE Role/Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRole([FromBody] Role p_role)
        {
            _repo.Delete(p_role);
            _repo.Save();
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;

namespace WebAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Dependency injection
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: api/<RoleController>\
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllRole()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<RoleController>/5
        [HttpGet("{p_id}")]
        public IActionResult GetRoleById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }

        // POST api/Role/add
        [HttpPost("add")]
        public IActionResult AddRole([FromBody] Role p_role)
        {
            _repo.Create(p_role);
            _repo.Save();
            return Created("api/Role/add", p_role);
        }


        // PUT api/Role/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateRole([FromBody] Role p_role)
        {
            _repo.Update(p_role);
            _repo.Save();
            return Ok();
        }

            // DELETE api/Role/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRole([FromBody] Role p_role)
        {
            _repo.Delete(p_role);
            _repo.Save();
            return Ok();
        }
    }
}
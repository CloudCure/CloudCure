using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Dependency injection
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository p_repo){_repo = p_repo;}

        // GET: Role/Get/All
        [HttpGet("Get/All")]
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: Role/Get/Id
        [HttpGet("Get/{p_id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetById(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        // POST: Role/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Role p_role){
            try{
                _repo.Create(p_role);
                _repo.Save();
                return Created("Role/Add", p_role);
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        // PUT: Role/Update/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] Role p_role){
            try{
                _repo.Update(p_role);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        // DELETE: Role/Delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Role p_role){
            try{
                _repo.Delete(p_role);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }
    }
}
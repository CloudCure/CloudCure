using System;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Data;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        //Dependency Injection
        private readonly IVitalsRepository _repo;

        public VitalsController(IVitalsRepository p_repo) { _repo = p_repo; }

        //GET: Vitals/All
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

        //GET: Vitals/Id
        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int p_id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(p_id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //POST: Vitals/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Vitals p_vitals)
        {
            try
            {
                _repo.Create(p_vitals);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        //PUT: Vitals/Id
        [HttpPut("Update/{id}")]
        public IActionResult UpdateVitals([FromBody] Vitals p_vitals)
        {
            try
            {
                _repo.Update(p_vitals);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        //Delete: Vitals/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteVitals([FromBody] Vitals p_vitals)
        {
            try
            {
                _repo.Delete(p_vitals);
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
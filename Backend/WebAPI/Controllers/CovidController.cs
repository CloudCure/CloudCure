using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidRepository _repo;

        public CovidController(ICovidRepository p_repo) { _repo = p_repo; }

        // GET: api/covid/Get/All
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

        // GET api/covid/Get/{p_id}
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

        //POST covid/add 
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CovidVerify p_covid)
        {
            try
            {
                _repo.Create(p_covid);
                _repo.Save();
                return Created("Covid/Add", p_covid);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid create form.");
            }
        }

        // DELETE covid/delete/{p_id}
        [HttpDelete("Delete/{p_id}")]
        public IActionResult Delete(int p_id)
        {
            try
            {
                var topic = _repo.GetByPrimaryKey(p_id);
                _repo.Delete(topic);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        // PUT api/covid/update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] CovidVerify p_covid)
        {
            try
            {
                p_covid.Id = id;
                _repo.Update(p_covid);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid put request.");
            }
        }
    }
}
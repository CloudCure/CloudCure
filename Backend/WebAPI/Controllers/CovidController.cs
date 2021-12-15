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
    [Route("api/[Controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        //Dependency injection for CovidRepository
        private readonly ICovidRepository _repo;

        public CovidController(ICovidRepository p_repo)
        {
            _repo = p_repo;
        }

        // GET: api/covid/all
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {   try
            {
            return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET api/covid/{p_id}
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

        //POST api/covid/add 
        [HttpPost("Add")]
        public IActionResult AddCovid([FromBody] CovidVerify p_covid)
        {
            try
            {
            _repo.Create(p_covid);
            _repo.Save();
            return Created("api/covid/add", p_covid);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        // DELETE api/delete/{p_id}
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
                return BadRequest("Not a valid Id");
            }
        }

        // PUT api/covid/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult CovidVerify([FromBody] CovidVerify p_covid)
        {
            try
            {
                _repo.Update(p_covid);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Invalid Input");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers {
    [Route("api/[Controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidRepository _repo;

        public CovidController(ICovidRepository p_repo)
        {
            _repo = p_repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(id));
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
            _repo.Create(p_covid);
            _repo.Save();
            return Created("api/UserAPI/Add", p_covid);
        }

        // DELETE <TopicController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var topic = _repo.GetByPrimaryKey(id);
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
    }
}
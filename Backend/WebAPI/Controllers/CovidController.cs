using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;
using System.Collections.Generic;
using Models.Diagnosis;
using System.Linq;

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
                List<CovidVerify> assessment = _repo.GetAll().ToList();
                if (assessment.Count == 0)
                    throw new Exception("No Data Found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET api/covid/Get/{id}
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

        //POST covid/add 
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CovidVerify p_covid)
        {
            try
            {
                 if (p_covid == null)
                    throw new Exception("Invalid data!");
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

        // DELETE covid/delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var topic = _repo.GetById(id);
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
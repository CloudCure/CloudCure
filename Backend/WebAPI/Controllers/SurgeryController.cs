using System.Linq;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class SurgeryController : ControllerBase
    {
        private readonly IRepository<Surgery> _repo;

        public SurgeryController(IRepository<Surgery> context)
        {
            _repo = context;
        }


        // GET: surgery/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                List<Surgery> s = _repo.GetAll().ToList();
                if (s.Count == 0)
                    throw new Exception("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // GET: surgery/Get/{id}
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
                return BadRequest("Failed to update");
            }
        }

        // DELETE surgery/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Surgery p_surgery)
        {
            try
            {
                _repo.Delete(p_surgery);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");

            }

        }

        // PUT surgery/Update
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Surgery p_surgery)
        {
            try
            {
                if (_repo.GetById(id) == null || p_surgery == null)
                    throw new Exception("Update failed!");
                _repo.Update(p_surgery);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // POST surgery/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Surgery p_surgery)
        {
            try
            {
                if (p_surgery == null)
                    throw new Exception("Invalid data!");
                _repo.Create(p_surgery);
                _repo.Save();
                return Created("Surgery/Add", p_surgery);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using Models.Diagnosis;
using Data;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentRepository _repo;

        public AssessmentController(IAssessmentRepository p_repo) { _repo = p_repo; }

        // GET: api/Assessment/Get/All
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

        // GET api/Assessment/Get/{p_id}
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

        //POST api/Assessment/add 
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Assessment p_Assessment)
        { // Fixme: This is not working
            try
            {
                _repo.Create(p_Assessment);
                _repo.Save();
                return Ok();
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

        // PUT api/Assessment/update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Assessment p_Assessment)
        { // Fixme: This is not working
            try
            {
                p_Assessment.Id = id;
                _repo.Update(p_Assessment);
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
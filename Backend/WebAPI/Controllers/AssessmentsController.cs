using System.IO;
using Microsoft.AspNetCore.Mvc;
using System;
using Models.Diagnosis;
using Data;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {   
        //Dependency injection
        private readonly IAssessmentRepository _repo;
        public AssessmentController(IAssessmentRepository p_repo) { _repo = p_repo; }

        // GET: Assessment/Get/All
        [HttpGet("Get/All")]//Gets all list(s) of assessment
        public IActionResult GetAll()
        {
            try
            {
                List<Assessment> assessment = _repo.GetAll().ToList();
                if (assessment.Count == 0)
                    throw new FileNotFoundException("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all Assessment request.");//Logs all bad requests into separate file
            }
        }

        // GET Assessment/Get/{Id}
        [HttpGet("Get/{id}")]//Gets assessment by Id
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new InvalidDataException("Invalid Id");
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Get request.");
            }
        }

        //GET: Assessment/{Id}
        [HttpGet("Get/Diagnosis/{id}")]//Gets diagnosis by Id
        public IActionResult GetByDiagnosisId(int id)
        {
            try
            {   if (_repo.SearchByDiagnosisId(id) == null || id < 1)
                    throw new InvalidDataException("Invaild Id");
                return Ok(_repo.SearchByDiagnosisId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //POST Assessment/Add 
        [HttpPost("Add")]//Adds new assessment
        public IActionResult Add([FromBody] Assessment p_Assessment)
        {
            try
            {
                if (p_Assessment == null)
                    throw new InvalidDataException("Invalid data!");
                _repo.Create(p_Assessment);
                _repo.Save();
                return Created("Assessment/Add", p_Assessment);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Add Request.");
            }
        }

        // DELETE Delete/{id}
        [HttpDelete("Delete/{id}")]//Deletes Assessment by Id
        public IActionResult Delete(int id)
        {
            try
            {
                var topic = _repo.GetById(id);
                if (topic == null)
                    throw new InvalidDataException("Delete failed!");
                _repo.Delete(topic);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Delete request.");
            }
        }

        // PUT Assessment/update/{id}
        [HttpPut("Update/{id}")]//Updates assessment by Id
        public IActionResult Update(int id, [FromBody] Assessment p_Assessment)
        {
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
                return BadRequest("Invalid Assessments Update");
            }
        }
    }
}
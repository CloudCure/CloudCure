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
        private readonly IAssessmentRepository _repo;
        public AssessmentController(IAssessmentRepository p_repo) { _repo = p_repo; }

        // GET: api/Assessment/Get/All
        [HttpGet("Get/All")]
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
                return BadRequest("Invalid get all Assessment request.");
            }
        }

        // GET api/Assessment/Get/{id}
        [HttpGet("Get/{id}")]
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

        //GET: Assessment/PatientId
        [HttpGet("Get/Diagnosis/{id}")]
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

        //POST api/Assessment/add 
        [HttpPost("Add")]
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

        // DELETE api/delete/{id}
        [HttpDelete("Delete/{id}")]
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

        // PUT api/Assessment/update/{id}
        [HttpPut("Update/{id}")]
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
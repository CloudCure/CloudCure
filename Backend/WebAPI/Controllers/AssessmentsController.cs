using Microsoft.AspNetCore.Mvc;
using System;
using Models.Diagnosis;
using Data;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("Assessment")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentRepository _repo;

        public AssessmentController(IAssessmentRepository p_repo) { _repo = p_repo; }

        // GET: Assessment/Get/All
        [HttpGet("Get/All")]
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid get all Assessment request.");
            }
        }
        // GET: Assessment/Get/{p_id}
        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Get request.");
            }
        }
        //POST: Assessment/Add 
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Assessment p_Assessment){ 
            try{
                _repo.Create(p_Assessment);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Add Request.");
            }
        }
        // DELETE: Assessment/Delete/{p_id}
        [HttpDelete("Delete/{p_id}")]
        public IActionResult Delete(int p_id){
            try{
                var topic = _repo.GetByPrimaryKey(p_id);
                _repo.Delete(topic);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid Assessment Delete request.");
            }
        }
        // PUT: Assessment/update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Assessment p_Assessment){ 
            try{
                p_Assessment.Id = id;
                _repo.Update(p_Assessment);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid Assessments Update");
            }
        }
    }
}
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repo;
        private readonly IAllergyRepository _allergy;

        public PatientController(IPatientRepository p_repo){_repo = p_repo;}
        
        // GET: Patient/Get/All
        [HttpGet("Get/All")] 
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid get all patient request.");
            }
        }

        // GET: Patient/Get/Id
        [HttpGet("Get/{p_id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid search id");
            }
        }

        // POST Patient/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Patient p_patient){
            try{
                _repo.Create(p_patient);
                _repo.Save();
                return Ok();

            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid search id");
            }
        }

        // PUT: Patient/Update/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] Patient p_patient){
            try{
                _repo.Update(p_patient);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // DELETE: Patient/Delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Patient p_patient){
            try{
                _repo.Delete(p_patient);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to delete patient");
            }
        }
    }
}
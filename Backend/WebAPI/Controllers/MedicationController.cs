using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("Medication")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IRepository<Medication> _repo;
        public MedicationController(IRepository<Medication> p_repo){_repo = p_repo;}

        // GET: Medication/All
        [HttpGet("All")]
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // DELETE: Medication/Delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Medication p_medication){
            try{
                _repo.Delete(p_medication);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to delete Medication");
            }
        }

        // PUT: Medication/Update/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Medication p_medication){
            try{
                p_medication.Id = id;
                _repo.Update(p_medication);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // POST: Medication/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Medication p_medication){
            try{
                _repo.Create(p_medication);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to Add Medication");
            }
        }
    }
}

using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyRepository _repo;
        public AllergyController(IAllergyRepository p_repo){_repo = p_repo;}
        
        // GET: Allergy/Get/All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
        // GET: Allergy/Get/{p_id}
        [HttpGet("Get/{p_id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetById(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to get allergy by id");
            }
        }

        // DELETE: Allergy/Delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Allergy p_allergy){
            try{
                _repo.Delete(p_allergy);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to delete allergy");
            }
        }

        // PUT: Allergy/Update/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] Allergy p_allergy){
            try{
                _repo.Update(p_allergy);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update allergy");
            }
        }

        // POST: Allergy/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Allergy p_allergy){
            try{
                _repo.Create(p_allergy);
                _repo.Save();
                return Created("Allergy/Add", p_allergy);
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to add allergy");
            }
        }
    }
}
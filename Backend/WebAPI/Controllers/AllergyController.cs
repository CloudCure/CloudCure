using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id){
            try{
                return Ok(_repo.GetById(id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to get allergy by id");
            }
        }

        [HttpGet("Get/Patient{id}")]
        public IActionResult GetByPatientId(int id)
        {
            try
            {
                return Ok(_repo.SearchByPatientId(id));
            }
            catch (Exception e)
            {
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

        // PUT Allergy/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Allergy p_allergy){
            try{
                var allergy = _repo.GetById(id);
                
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
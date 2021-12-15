using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
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

        public AllergyController(IAllergyRepository p_repo)
        {
            _repo = p_repo;
        }
      }

        
        // GET: Allergy/Get/All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("No results");
            }
        }
        
        [HttpGet("Get/{p_id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Id not found");
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
        public IActionResult AddAllergy([FromBody] Allergy p_allergy)
        {
            try
            {
                _allergy.Create(p_allergy);
                _allergy.Save();
                return Created("Allergy/Add", p_allergy);
            }
            catch (Exception e)
            {

        public IActionResult Add([FromBody] Allergy p_allergy){
            try{
                _repo.Create(p_allergy);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to Add Allergy");
            }
        }
    }
}
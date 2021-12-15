using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;

namespace WebAPI.Controllers
{
    [Route("allergy")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyRepository _allergy;

        public AllergyController(IAllergyRepository p_allergy)
        {
            _allergy = p_allergy;
        }

        // GET: Allergy/All
        [HttpGet("all")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllAllergy()
        {
            try
            {
                return Ok(_allergy.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // DELETE allergy/delete/Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAllergy([FromBody] Allergy p_allergy)
        {
            try
            {
                _allergy.Delete(p_allergy);
                _allergy.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // PUT Allergy/Edit
        [HttpPut("edit/{id}")]
        public IActionResult UpdateAllergy([FromBody] Allergy p_allergy)
        {
            try
            {
                _allergy.Update(p_allergy);
                _allergy.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // POST Allergy/Add
        [HttpPost("add")]
        public IActionResult AddAllergy([FromBody] Allergy p_allergy)
        {
            try
            {
                _allergy.Create(p_allergy);
                _allergy.Save();
                return Created("allergy/add", p_allergy);
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }
    }
}
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;

namespace WebAPI.Controllers
{
    [Route("medication")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IRepository<Medication> medicationRepository;

        public MedicationController(IRepository<Medication> context)
        {
            medicationRepository = context;
        }

        // GET: medication/All
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll()
        {
            try
            {
                return Ok(medicationRepository.GetAll());
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // DELETE Medication/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Delete(p_medication);
                medicationRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");

            }
        }

        // PUT Medication/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Update(p_medication);
                medicationRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // POST Medication/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Create(p_medication);
                medicationRepository.Save();
                return Created("allergy/add", p_medication);
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
    }
}
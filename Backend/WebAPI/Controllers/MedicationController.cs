using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
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
        [HttpGet("all")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllMedication()
        {
            try
            {
                return Ok(medicationRepository.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // DELETE Medication/delete/Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMedication([FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Delete(p_medication);
                medicationRepository.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // PUT Medication/Edit
        [HttpPut("edit/{id}")]
        public IActionResult UpdateMedication([FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Update(p_medication);
                medicationRepository.Save();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }

        // POST Medication/Add
        [HttpPost("add")]
        public IActionResult AddMedication([FromBody] Medication p_medication)
        {
            try
            {
                medicationRepository.Create(p_medication);
                medicationRepository.Save();
                return Created("allergy/add", p_medication);
            }
            catch (Exception)
            {
                return BadRequest("Failed to update");
            }
        }
    }
}
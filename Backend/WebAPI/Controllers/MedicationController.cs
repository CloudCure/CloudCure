using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IRepository<Medication> medicationRepository;

        public MedicationController(IRepository<Medication> context)
        {
            medicationRepository = context;
        }


        // GET: medication/All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll()
        {
            try
            {
                return Ok(medicationRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("No results");
            }
        }

        // GET: medication/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id){
            try{
                return Ok(medicationRepository.GetById(id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("No results");
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
                return BadRequest("Failed to delete");
            }
        }

        // PUT Medication/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] Medication p_medication)
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
                return Created("Medication/Add", p_medication);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to Add");
            }
        }
    }
}

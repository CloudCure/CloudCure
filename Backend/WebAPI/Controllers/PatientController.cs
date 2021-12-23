using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //Dependency injection
        private readonly IPatientRepository _repo;

        public PatientController(IPatientRepository p_repo, IAllergyRepository p_allergy)
        {
            _repo = p_repo;
        }
        // GET: Patient/All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.GetAllWithNav());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all patients request.");
            }
        }

        // GET Patient/Id
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repo.GetbyPatientWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get patient by id request.");
            }
        }

        // POST Patient/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Patient p_patient)
        {
            try
            {
                _repo.Create(p_patient);
                _repo.Save();
                return Created("Patient/Add", p_patient);

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid patient add request");
            }
        }

        // PUT Patient/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Patient p_patient)
        {
            try
            {
                // CHECK PLEASE
                _repo.Update(p_patient);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid patient update request");
            }
        }

        // DELETE Patient/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Patient p_patient)
        {
            try
            {
                _repo.Delete(p_patient);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid patient delete request");
            }
        }
    }
}
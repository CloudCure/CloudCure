using System.IO;
using System.Linq;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;
using System.Collections.Generic;

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
                List<Patient> p = _repo.GetAllWithNav().ToList();
                if (p.Count == 0)
                    throw new FileNotFoundException("No data found");
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
                if (_repo.GetbyPatientWithNav(id) == null)
                    throw new InvalidDataException("Invaild Id");
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
                if (p_patient == null)
                    throw new InvalidDataException("Invalid data!");
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
                p_patient.Id = id;
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
                if (p_patient == null)
                    throw new InvalidDataException("Delete failed!");
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
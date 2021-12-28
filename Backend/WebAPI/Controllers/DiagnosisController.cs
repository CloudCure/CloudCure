using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        //Dependency injection
        private readonly IDiagnosisRepository DiagnosisRepository;

        public DiagnosisController(IDiagnosisRepository context)
        {
            DiagnosisRepository = context;
        }

        // GET: Diagnosis/Get/All
        [HttpGet("Get/All")]//Gets all diagnoses
        public IActionResult GetAll()
        {
            try
            {
                return Ok(DiagnosisRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all Diagnosis request");//Logs all bad requests into separate file
            }
        }

        // GET: Diagnosis/Get/{Id}
        [HttpGet("Get/{id}")]//Gets diagnosis by Id

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid  Diagnosis get request");
            }
        }

        // PUT: Diagnosis/Update/{Id}
        [HttpPut("Update/{id}")]//Updates Diagnosis by Id

        public IActionResult Update(int id, [FromBody] Diagnosis p_diagnosis)
        {
            try
            {
                p_diagnosis.Id = id;
                DiagnosisRepository.Update(p_diagnosis);
                DiagnosisRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Diagnosis Update");
            }
        }

        // DELETE: Diagnosis/Delete/Id
        [HttpDelete("Delete/{id}")]//Deletes Diagnosis by Id

        public IActionResult Delete(int id)
        {
            try
            {
                var ToBeDeleted = DiagnosisRepository.GetById(id);
                DiagnosisRepository.Delete(ToBeDeleted);
                DiagnosisRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Diagnosis Delete request");
            }
        }

        // GET: Diagnosis/GetPatientId/{Id}
        [HttpGet("Get/GetPatientId/{id}")]//Gets diagnosis by patient Id
        public IActionResult GetByPatientIdWithNav(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetByPatientIdWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get diagnosis by patient Id");
            }
        }

        // GET: Diagnosis/GetAllPatientId/{Id}
        [HttpGet("Get/GetAllPatient/{id}")]//Gets all Diagnosis by patient Id
        public IActionResult GetAllDiagnosisByPatientIdWithNav(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetAllDiagnosisByPatientIdWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get diagnosis by patient Id");
            }
        }

        // POST: Diagnosis/Add
        [HttpPost("Add")]//Adds new diagnosis
        public IActionResult Add([FromBody] Diagnosis p_diagnosis)
        {
            try
            {
                DiagnosisRepository.Create(p_diagnosis);
                DiagnosisRepository.Save();
                return Created("Diagnosis/Add", p_diagnosis);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Fail to Add diagnosis ");
            }
        }
    }
}
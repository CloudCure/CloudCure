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
        private readonly IRepository<Diagnosis> DiagnosisRepository;

        public DiagnosisController(IRepository<Diagnosis> context)
        {
            DiagnosisRepository = context;
        }

        // GET: Diagnosis/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(DiagnosisRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all Diagnosis request");
            }
        }

        [HttpGet("Get/{id}")]

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

        [HttpPut("Update/{id}")]

        public IActionResult Update(int id, [FromBody] Diagnosis p_diagnosis)
        {
            try
            {
                p_diagnosis.Id = id;
                DiagnosisRepository.Update(p_diagnosis);
                DiagnosisRepository.Save();
                return Ok();
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Diagnosis Update");
            }
      }

      [HttpDelete("Delete/{id}")]

      public IActionResult Delete(int id)
      {
          try
          {
              var ToBeDeleted = DiagnosisRepository.GetById(id);
              DiagnosisRepository.Delete(ToBeDeleted);
              DiagnosisRepository.Save();
              return Ok();
          }
          catch(Exception e)
          {
              Log.Error(e.Message);
              return BadRequest("Invalid Diagnosis Delete request");
              

          }
      }

    }
}
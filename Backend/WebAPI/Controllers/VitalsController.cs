using System.IO;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Data;
using Serilog;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        //Dependency Injection
        private readonly IVitalsRepository _repo;

        public VitalsController(IVitalsRepository p_repo) { _repo = p_repo; }

        //GET: Vitals/All
        [HttpGet("Get/All")]//Get list of all vitals
        public IActionResult GetAll()
        {
            try
            {
                List<Vitals> v = _repo.GetAll().ToList();
                if (v.Count == 0)
                    throw new FileNotFoundException("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");//Logs all bad requests into separate file
            }
        }

        //GET: Vitals/{Id}
        [HttpGet("Get/{id}")]//Gets vitals by Id
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new InvalidDataException("Invalid Id");
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //GET: Vitals/PatientId
        [HttpGet("Get/Diagnosis/{id}")]//Gets vitals by patient Id
        public IActionResult GetByDiagnosisId(int id)
        {
            try
            {
                if (_repo.SearchByDiagnosisId(id) == null)
                    throw new InvalidDataException("Invaild Id");
                return Ok(_repo.SearchByDiagnosisId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //POST: Vitals/Add
        [HttpPost("Add")]//Adds new vitals info 
        public IActionResult Add([FromBody] Vitals p_vitals)
        {
            try
            {
                if (p_vitals == null)
                    throw new InvalidDataException("Invalid data!");
                _repo.Create(p_vitals);
                _repo.Save();
                return Created("Vitals/Add", p_vitals);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        //PUT: Vitals/{Id}
        [HttpPut("Update/{id}")]//Updates vital info by Id
        public IActionResult Update(int id, [FromBody] Vitals p_vitals)
        {
            try
            {
                p_vitals.Id = id;
                _repo.Update(p_vitals);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }

        //Delete: Vitals/{Id}
        [HttpDelete("Delete/{id}")]//Delete vitals by Id
        public IActionResult Delete([FromBody] Vitals p_vitals)
        {
            try
            {
                if (p_vitals == null)
                    throw new InvalidDataException("Delete failed!");
                _repo.Delete(p_vitals);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid input.");
            }
        }
    }
}
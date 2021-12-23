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
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                List<Vitals> v = _repo.GetAll().ToList();
                if (v.Count == 0)
                    throw new Exception("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        //GET: Vitals/Id
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new Exception("Invalid Id");
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //GET: Vitals/PatientId
        [HttpGet("Get/Patient/{id}")]
        public IActionResult GetByPatientId(int id)
        {
            try
            {
                if (_repo.SearchByPatientId(id) == null)
                    throw new Exception("Invaild Id");
                return Ok(_repo.SearchByPatientId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //POST: Vitals/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Vitals p_vitals)
        {
            try
            {
                if (p_vitals == null)
                    throw new Exception("Invalid data!");
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

        //PUT: Vitals/Id
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Vitals p_vitals)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new Exception("Update failed!");
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

        //Delete: Vitals/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Vitals p_vitals)
        {
            try
            {
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
using System.IO;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyRepository _repo;

        public AllergyController(IAllergyRepository p_repo) { _repo = p_repo; }

        // GET: Allergy/Get/All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAll()
        {
            try
            {
                List<Allergy> allergy = _repo.GetAll().ToList();
                if (allergy.Count == 0)
                    throw new FileNotFoundException("No data found");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("No results found");
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (_repo.GetById(id) == null)
                    throw new ArgumentNullException("Invalid Id");
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to get allergy by id");
            }
        }

        [HttpGet("Get/Patient{id}")]
        public IActionResult GetByPatientId(int id)
        {
            try
            {
               if (_repo.SearchByPatientId(id) == null)
                    throw new ArgumentNullException("Invaild Id");
                return Ok(_repo.SearchByPatientId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to get allergy by id");
            }
        }

        // DELETE: Allergy/Delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Allergy p_allergy)
        {
            try
            {
                if (p_allergy == null)
                    throw new ArgumentNullException("Delete failed!");
                _repo.Delete(p_allergy);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to delete allergy");
            }
        }

        // PUT Allergy/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Allergy p_allergy)
        {
            try
            {
                p_allergy.Id = id;
                _repo.Update(p_allergy);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update allergy");
            }
        }

        // POST: Allergy/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Allergy p_allergy)
        {
            try
            {
                if (p_allergy == null)
                    throw new ArgumentNullException("Invalid data!");
                _repo.Create(p_allergy);
                _repo.Save();
                return Created("Allergy/Add", p_allergy);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to add allergy");
            }
        }
    }
}
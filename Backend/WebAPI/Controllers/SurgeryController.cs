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
    public class SurgeryController : ControllerBase
    {
        private readonly IRepository<Surgery> surgeryRepository;

        public SurgeryController(IRepository<Surgery> context)
        {
            surgeryRepository = context;
        }


        // GET: surgery/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(surgeryRepository.GetAll());
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // GET: surgery/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(surgeryRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // DELETE surgery/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Surgery p_surgery)
        {
            try
            {
                surgeryRepository.Delete(p_surgery);
                surgeryRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");

            }

        }

        // PUT surgery/Update
        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] Surgery p_surgery)
        {
            try
            {
                surgeryRepository.Update(p_surgery);
                surgeryRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }

        // POST surgery/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Surgery p_surgery)
        {
            try
            {
                surgeryRepository.Create(p_surgery);
                surgeryRepository.Save();
                return Created("Surgery/Add", p_surgery);
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }
    }
}

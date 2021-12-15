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
        public IActionResult GetAllSurgery()
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

        // DELETE surgery/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteSurgery([FromBody] Surgery p_surgery)
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

        // PUT surgery/Edit
        [HttpPut("Update/{id}")]
        public IActionResult UpdateSurgery([FromBody] Surgery p_surgery)
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
        public IActionResult AddSurgery([FromBody] Surgery p_surgery)
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

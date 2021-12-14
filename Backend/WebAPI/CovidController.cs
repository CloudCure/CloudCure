using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers {
    [Route("api/[Controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidRepository CovidRepository;

        public CovidController(ICovidRepository context)
        {
            CovidRepository = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(CovidRepository.GetAll());
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            try
            {
                return Ok(CovidRepository.GetByPrimaryKey(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }


        // DELETE <TopicController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var topic = CovidRepository.GetByPrimaryKey(id);
                CovidRepository.Delete(topic);
                CovidRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }
    }
}
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
    public class ConditionController : ControllerBase
    {


        private readonly IRepository<Condition> conditionRepository;

        public ConditionController(IRepository<Condition> context)
        {
            conditionRepository = context;
        }
        
        // GET: condition /All
        [HttpGet("Get/All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllCondition()
        {
            try
            {
                return Ok(conditionRepository.GetAll());
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }


        }

        // DELETE Condition/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCondition([FromBody] Condition p_condition)
        {
            try
            {
                conditionRepository.Delete(p_condition);
                conditionRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");

            }

        }

        // PUT Condition/Edit
        [HttpPut("Update/{id}")]
        public IActionResult UpdateCondition([FromBody] Condition p_condition)
        {
            try
            {
                conditionRepository.Update(p_condition);
                conditionRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }

        // POST Condition/Add
        [HttpPost("Add")]
        public IActionResult AddCondition([FromBody] Condition p_condition)
        {
            try
            {
                conditionRepository.Create(p_condition);
                conditionRepository.Save();
                return Created("Condition/Add", p_condition);
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }
    }
}

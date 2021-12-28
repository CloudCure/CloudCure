using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        //Dependency injection
        private readonly IConditionRepository conditionRepository;

        public ConditionController(IConditionRepository context)
        {
            conditionRepository = context;
        }

        // GET: Condition/Get/All
        [HttpGet("Get/All")]//Gets list of all conditions
        public IActionResult GetAll()
        {
            try
            {
                List<Condition> condition = conditionRepository.GetAll().ToList();
                if (condition.Count == 0)
                    throw new Exception("No data found");//If there are no conditions, returns "No data found"
                return Ok(conditionRepository.GetAll());
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Failed to update");//Logs all bad requests into separate file
            }
        }
        // GET: Condition/Get/{id}
        [HttpGet("Get/{id}")]//Gets condition by Id
        public IActionResult GetById(int id)
        {
            try
            {
                if (conditionRepository.GetById(id) == null)
                    throw new Exception("Invalid Id");
                return Ok(conditionRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        //GET: Condition/Get/Patient{Id}
        [HttpGet("Get/Patient{id}")]//Gets condition by patient Id
        public IActionResult GetByPatientId(int id)
        {
            try
            {
                if (conditionRepository.SearchByPatientId(id) == null)
                    throw new Exception("Invalid Id");
                return Ok(conditionRepository.SearchByPatientId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to get condition by id");
            }
        }

        // DELETE Condition/delete/Id
        [HttpDelete("Delete/{id}")]//Deletes condition by Id
        public IActionResult Delete([FromBody] Condition p_condition)
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
        [HttpPut("Update/{id}")]//Updates Condition by Id
        public IActionResult Update(int id, [FromBody] Condition p_condition)
        {
            try
            {

                p_condition.Id = id;
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
        [HttpPost("Add")]//Adds new condition
        public IActionResult Add([FromBody] Condition p_condition)
        {
            try
            {
                if (p_condition == null)
                    throw new Exception("Invalid data!");
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
using System.IO;
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
        private readonly IConditionRepository conditionRepository;

        public ConditionController(IConditionRepository context)
        {
            conditionRepository = context;
        }

        // GET: Condition/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                List<Condition> condition = conditionRepository.GetAll().ToList();
                if (condition.Count == 0)
                    throw new FileNotFoundException("No data found");
                return Ok(conditionRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
        // GET: Condition/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (conditionRepository.GetById(id) == null)
                    throw new InvalidDataException("Invalid Id");
                return Ok(conditionRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        [HttpGet("Get/Patient{id}")]
        public IActionResult GetByPatientId(int id)
        {
            try
            {
                if (conditionRepository.SearchByPatientId(id) == null)
                    throw new InvalidDataException("Invaild Id");
                return Ok(conditionRepository.SearchByPatientId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Failed to get congition by id");
            }
        }

        // DELETE Condition/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Condition p_condition)
        {
            try
            {
                if (p_condition == null)
                    throw new InvalidDataException("Delete failed!");
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
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Condition p_condition)
        {
            try
            {
                if (p_condition == null)
                    throw new InvalidDataException("Invalid data!");
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
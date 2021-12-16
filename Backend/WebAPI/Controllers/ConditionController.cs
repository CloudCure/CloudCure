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
        
        // GET: Condition/All
        [HttpGet("Get/All")] 
        public IActionResult GetAll(){
            try{
                return Ok(conditionRepository.GetAll());
            }catch (Exception e){

                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }
        // GET: Condition/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id){
            try{
                return Ok(conditionRepository.GetById(id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
        }

        // DELETE Condition/delete/Id
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromBody] Condition p_condition){
            try{
                conditionRepository.Delete(p_condition);
                conditionRepository.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");

            }

        }

        // PUT Condition/Edit
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Condition p_condition){
            try{
                p_condition.Id = id;
                conditionRepository.Update(p_condition);
                conditionRepository.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }

        // POST Condition/Add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Condition p_condition){
            try{
                conditionRepository.Create(p_condition);
                conditionRepository.Save();
                return Created("Condition/Add", p_condition);
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Failed to update");
            }

        }
    }
}

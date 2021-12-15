using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Data;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("Covid")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidRepository _repo;
        public CovidController(ICovidRepository p_repo) { _repo = p_repo; }

        // GET: Covid/Get/All
        [HttpGet("Get/All")]
        public IActionResult GetAll(){
            try{
                return Ok(_repo.GetAll());
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid get all request.");
            }
        }

        // GET: Covid/Get/{p_id}
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int p_id){
            try{
                return Ok(_repo.GetByPrimaryKey(p_id));
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        //POST: Covid/Add 
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CovidVerify p_covid){
            try{
                _repo.Create(p_covid);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid create form.");
            }
        }

        // DELETE: Covid/Delete/{p_id}
        [HttpDelete("Delete/{p_id}")]
        public IActionResult Delete(int p_id){
            try{
                var topic = _repo.GetByPrimaryKey(p_id);
                _repo.Delete(topic);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        // PUT: Covid/Update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] CovidVerify p_covid){
            try{
                p_covid.Id = id;
                _repo.Update(p_covid);
                _repo.Save();
                return Ok();
            }catch (Exception e){
                Log.Error(e.Message);
                return BadRequest("Invalid put request.");
            }
        }
    }
}
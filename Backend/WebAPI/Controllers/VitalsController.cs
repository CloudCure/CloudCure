using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Vitals")]
    public class VitalsController : ControllerBase
    {
        //Dependency Injection
        private readonly IVitalsRepository _repo;

        public VitalsController(IVitalsRepository p_repo)
        {
            _repo = p_repo;
        }

        //GET: Vitals/All
        [HttpGet("All")] //("All") Will give an endpoint that ends with All
        public IActionResult GetAllVitals()
        {   
            try
            {
            return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all request");
            }
        }

        //GET: Vitals/Id
        [HttpGet("{p_id}")]//("ID") Will give an endpoint that ends with Id
        public IActionResult GetVitalsById(int p_id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(p_id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid ID");
            }
        }
        //POST: Vitals/Add
        [HttpPost("add")]//("Add") Will give an endpoint that ends with Add
        public IActionResult AddVitals([FromBody] Vitals p_vitals)
         {
            try
            {
                _repo.Create(p_vitals);
                _repo.Save();
                return Created("vitals/add", p_vitals);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Input");
            }
        }
        //PUT: Vitals/Id
        [HttpPut("edit/{id}")]//("ID") Will give an endpoint that ends with Id
        public IActionResult UpdateVitals([FromBody] Vitals p_vitals)
        {
            try
            {
                _repo.Update(p_vitals);
                _repo.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Invalid ID");
            }
        }

        //Delete: Vitals/Id
        [HttpDelete("delete/{id}")]//("ID") Will give an endpoint that ends with Id
        public IActionResult DeleteVitals([FromBody] Vitals p_vitals)
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
                return BadRequest("Invalid ID");
            }
        }
    }
}
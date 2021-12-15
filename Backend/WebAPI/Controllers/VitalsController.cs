using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;

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
        [HttpGet("All")] //("All") Will give a case-insensitive endpoint that ends with All
        public IActionResult GetAllVitals()
        {
            return Ok(_repo.GetAll());
        }

        //GET: Vitals/{p_id}
        [HttpGet("{p_id}")]
        public IActionResult GetVitalsById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }

        //POST: Vitals/Add
        [HttpPost("add")]
        public IActionResult AddVitals([FromBody] Vitals p_vitals)
        {
            _repo.Create(p_vitals);
            _repo.Save();
            return Created("Vitals/add", p_vitals);
        }

        //PUT: Vitals/{id}
        [HttpPut("edit/{id}")]
        public IActionResult UpdateVitals([FromBody] Vitals p_vitals)
        {
            _repo.Update(p_vitals);
            _repo.Save();
            return Ok();
        }

        //Delete: Vitals/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteVitals([FromBody] Vitals p_vitals)
        {
            _repo.Delete(p_vitals);
            _repo.Save();
            return Ok();
        }
    }
}
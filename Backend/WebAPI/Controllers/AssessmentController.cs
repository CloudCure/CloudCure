using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using Models.Diagnosis;

namespace WebAPI.Controllers
{
    [Route("Assessment")]
    [ApiController]
    
    public class AssessmentController : ControllerBase
    {
        //Dependency Injection
        private readonly IAssessmentRepository _repo;

        public AssessmentController(IAssessmentRepository p_repo)
        {
            _repo = p_repo;
        }

        //GET: Assessment/All
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllAssessment()
        {
            return Ok(_repo.GetAll());
        }

        //GET Assessment/Id
        [HttpGet("{p_id}")]
        public IActionResult GetAssessmentById(int p_id)
        {
            return Ok(_repo.GetByPrimaryKey(p_id));
        }

        // POST Assessment/Add
        [HttpPost("add")]
        public IActionResult AddAssessment([FromBody] Assessment p_role)
        {
            _repo.Create(p_role);
            _repo.Save();
            return Created("Assessment/add", p_role);
        }


        // PUT Assessment/Edit
        [HttpPut("edit/{id}")]
        public IActionResult UpdateAssessment([FromBody] Assessment p_role)
        {
            _repo.Update(p_role);
            _repo.Save();
            return Ok();
        }

        // DELETE Assessment/Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAssessment([FromBody] Assessment p_role)
        {
            _repo.Delete(p_role);
            _repo.Save();
            return Ok();
        }
    }

}   
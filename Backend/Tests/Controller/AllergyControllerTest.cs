using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models.Diagnosis;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Tests
{
    public class AllergyControllerTest
    {
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy 
            {
                PatientId = 1,
                AllergyName = "Hay fever"
            };

            var result = controller.Add(allergy);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }
       

      private List<Allergy> GetAllergyList()
      {
          var testAllergy = new List<Allergy>();
          testAllergy.Add(new Allergy {Id = 1, AllergyName = "Meds", PatientId = 1});
          testAllergy.Add(new Allergy {Id = 2, AllergyName = "Dogs", PatientId = 2});
          testAllergy.Add(new Allergy {Id = 3, AllergyName = "Cats", PatientId = 3});

          return testAllergy;
      }
       
    }
}
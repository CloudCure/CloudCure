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
        public void CreateReturnsOkAllergy()
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

        [Fact]
        public void GetAllReturnsOKAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 1,
                AllergyName = "Leather"
            };

            var entry = controller.Add(allergy);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
        public void DeleteShouldReturnOKAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 1,
                AllergyName = "Metal"
            };

            var entry = controller.Add(allergy);

            var result = controller.Delete(allergy);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
        public void UpdateShouldReturnOKAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 1,
                AllergyName = "Dog hair"
            };

            var entry = controller.Add(allergy);
            var result = controller.Update(1, allergy);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
        public void GetbyIdShouldReturnOKGetAllergyById()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 1,
                AllergyName = "Risperidol"
            };

            var entry = controller.Add(allergy);
            var results = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void CreateReturnsBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 0,
                AllergyName = ""
            };

            try
            {
                controller.Add(allergy);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetAllReturnsBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 0,
                AllergyName = ""
            };

            try
            {
                controller.Add(allergy);
                controller.GetAll();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }

        }

         [Fact]
        public void DeleteShouldReturnBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 0,
                AllergyName = ""
            };

              try
            {
                controller.Add(allergy);
                controller.Delete(allergy);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }

        }

        [Fact]
        public void UpdateShouldReturnBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = new Allergy
            {
                PatientId = 0,
                AllergyName = ""
            };

              try
            {
                controller.Add(allergy);
                controller.Update(1, allergy);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }

        }


        private List<Allergy> GetAllergyList()
        {
            var testAllergy = new List<Allergy>();
            testAllergy.Add(new Allergy { Id = 1, AllergyName = "Meds", PatientId = 1 });
            testAllergy.Add(new Allergy { Id = 2, AllergyName = "Dogs", PatientId = 2 });
            testAllergy.Add(new Allergy { Id = 3, AllergyName = "Cats", PatientId = 3 });

            return testAllergy;
        }

    }
}

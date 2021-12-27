using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models.Diagnosis;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class AllergyControllerTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public AllergyControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = AllergyControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void CreateReturnsOkAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var allergy = GetAllergy();

            var result = controller.Add(allergy);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllReturnsOKAllergy()
        {
            using (var context = new CloudCureDbContext(_options))
            {

                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var allergy = GetAllergy();

                var entry = controller.Add(allergy);
                var result = controller.GetAll();
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(200, okResponse.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldReturnOKAllergy()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var allergy = repo.GetById(1);

                var result = controller.Delete(allergy);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKAllergy()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var allergy = GetAllergy();

                var result = controller.Update(1, allergy);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOKGetAllergyById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByPatientIdShouldReturnOk()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var result = controller.GetByPatientId(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByPatientIdShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var result = controller.GetByPatientId(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void CreateReturnsBadRequestAllergy()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnBadRequestAllergy()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                var controller = new AllergyController(repo);

                var result = controller.Delete(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnBadRequestAllergy()
        {
            var repository = new Mock<IAllergyRepository>();
            var controller = new AllergyController(repository.Object);

            var results = controller.Update(-1, null);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        private List<Allergy> GetAllergyList()
        {
            var testAllergy = new List<Allergy>();
            testAllergy.Add(new Allergy { Id = 1, AllergyName = "Meds", PatientId = 1 });
            testAllergy.Add(new Allergy { Id = 2, AllergyName = "Dogs", PatientId = 2 });
            testAllergy.Add(new Allergy { Id = 3, AllergyName = "Cats", PatientId = 3 });

            return testAllergy;
        }

        private Allergy GetAllergy()
        {
            return new Allergy
            {
                PatientId = 1,
                AllergyName = "Tylenol"
            };
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Patients.AddRange(
                    new Patient
                    {
                        Allergies = new List<Allergy>{
                            new Allergy
                            {
                                PatientId = 1,
                                AllergyName = "Dogs"

                            },
                            new Allergy
                            {
                                PatientId = 1,
                                AllergyName = "Haldol"
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class MedicationControllerTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public MedicationControllerTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = medicationTest.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void CreateReturnsOkMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var result = controller.Add(medication);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldGiveBadResponse()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<Medication> repo = new Repository<Medication>(context);
                var controller = new MedicationController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsOKMedication()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<Medication> repo = new Repository<Medication>(context);
                var controller = new MedicationController(repo);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGiveBadResponse()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnOKMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var entry = controller.Add(medication);

            var result = controller.Delete(medication);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<Medication> repo = new Repository<Medication>(context);
                var controller = new MedicationController(repo);

                var result = controller.Delete(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKMedication()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<Medication> repo = new Repository<Medication>(context);
                var controller = new MedicationController(repo);

                var m = new Medication
                {
                    PatientId = 1,
                    MedicationName = "Tylenol"
                };

                var result = controller.Update(1, m);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<Medication> repo = new Repository<Medication>(context);
                var controller = new MedicationController(repo);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Medications.Add(new Medication{
                    PatientId = 1,
                    MedicationName = "Advil"
                });
                context.SaveChanges();
            }
        }
    }
}
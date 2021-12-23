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
    public class VitalsControllerTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public VitalsControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = vitalsTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void CreateReturnsOkVitals()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var v = getVitals();

                var result = controller.Add(v);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(201, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsOKVitals()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var vital = getVitals();

                var entry = controller.Add(vital);
                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldReturnOKVital()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var vital = repo.GetById(1);

                var result = controller.Delete(vital);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKVitals()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var vital = getVitals();

                var result = controller.Update(1, vital);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOKGetVitalsById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetbyPatientIdShouldReturnOK()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var result = controller.GetByPatientId(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGiveBadRequest()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var results = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldGiveBadRequest()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var vital = getVitals();

            var entry = controller.Add(vital);
            var results = controller.GetById(-1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void GetByPatientIdShouldGiveBadRequest()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var vital = getVitals();

            var entry = controller.Add(vital);
            var results = controller.GetByPatientId(-1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldGiveBadRequest()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var results = controller.Update(-1, null);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var vital = getVitals();

                var result = controller.Delete(vital);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void CreateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repo = new VitalsRepository(context);
                var controller = new VitalsController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private Vitals getVitals()
        {
            return new Vitals
            {
                PatientId = 1,
                Systolic = 120,
                Diastolic = 80,
                OxygenSat = 96.5,
                HeartRate = 70,
                RespiratoryRate = 12,
                Temperature = 98.6,
                Height = 75,
                Weight = 145,
            };
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Vitals.AddRange(
                    new Vitals
                    {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Temperature = 98.6,
                        Height = 75,
                        Weight = 145,
                        EncounterDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
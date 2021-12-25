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
    public class SurgeryControllerTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public SurgeryControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = surgeryControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void CreateReturnsOkSurgery()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            var surgery = new Surgery
            {
                PatientId = 1,
                SurgeryName = "Right Knee"
            };

            var result = controller.Add(surgery);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.Add(null);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(400, okResponse.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsOK()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.GetAll();
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(200, okResponse.StatusCode);
            }
        }

        [Fact]
        public void GetAllShoudGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(400, okResponse.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldReturnOKSurgery()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            var surgery = new Surgery
            {
                PatientId = 1,
                SurgeryName = "Right Knee"
            };

            var entry = controller.Add(surgery);

            var result = controller.Delete(surgery);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.Delete(null);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(400, okResponse.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOK()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var surgery = new Surgery
                {
                    PatientId = 1,
                    SurgeryName = "Right Knee"
                };

                var entry = controller.Add(surgery);
                var result = controller.Update(2, surgery);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(200, okResponse.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.Update(-1, null);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(400, okResponse.StatusCode);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOK()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.GetById(1);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(200, okResponse.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);
                var controller = new SurgeryController(repo);

                var result = controller.GetById(-1);
                var okResponse = (IStatusCodeActionResult)result;
                Assert.Equal(400, okResponse.StatusCode);
            }
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Surgeries.AddRange(
                    new Surgery
                    {
                        PatientId = 1,
                        SurgeryName = "Right Knee"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
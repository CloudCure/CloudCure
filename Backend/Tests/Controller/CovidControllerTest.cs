using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class CovidControllerTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public CovidControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = CovidControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void CreateReturnsOkCovid()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = GetCovid();


            var result = controller.Add(covid);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnException()
        {
             using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsOKCovid()
        {
              using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var covid = GetCovid();

                var entry = controller.Add(covid);
                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
             var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnOKCovid()
        {
             using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var covid = repo.GetById(1);

                var result = controller.Delete(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
              using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var covid = GetCovid();

                var result = controller.Delete(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOKGetCovidById()
        {
               using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = GetCovid();

            var entry = controller.Add(covid);
            var results = controller.GetById(-1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldReturnOKCovid()
        {
             using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var controller = new CovidController(repo);

                var covid = GetCovid();

                var result = controller.Update(1, covid);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = GetCovid();

            var entry = controller.Add(covid);
            var results = controller.Update(-1, null);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }
        private CovidVerify GetCovid()
        {
            return new CovidVerify
            {
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true",
                UserId = 1
            };
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CovidVerify covid = new CovidVerify
                {
                    question1 = "true",
                    question2 = "true",
                    question3 = "true",
                    question4 = "true",
                    question5 = "true",
                    UserId = 1
                };

                context.CovidAssessments.Add(covid);
                context.SaveChanges();
            }
        }
    }
}
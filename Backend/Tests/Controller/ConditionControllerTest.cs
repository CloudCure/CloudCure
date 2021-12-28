using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests
{
    public class ConditionControllerTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public ConditionControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = ConditionControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void CreateReturnsOkCondition()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);

            var condition = GetCondition();

            var result = controller.Add(condition);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnExceptionCondition()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllReturnsOKCondition()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var condition = GetCondition();

                var entry = controller.Add(condition);
                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }

        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);

            var results = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnOKCondition()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var vital = repo.GetById(1);

                var result = controller.Delete(vital);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var assessment = GetCondition();

                var result = controller.Delete(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKCondition()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var condition = GetCondition();

                var result = controller.Update(1, condition);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);

            var condition = GetCondition();

            var entry = controller.Add(condition);
            var results = controller.Update(-1, null);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void GetByPatientIdShouldReturnOk()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var result = controller.GetByPatientId(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetPatientIdShouldReturnBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var result = controller.GetByPatientId(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldReturnOk()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldReturnBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                var controller = new ConditionController(repo);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private static Condition GetCondition()
        {
            return new Condition
            {
                PatientId = 1,
                ConditionName = "Blood Pressure"
            };
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Conditions.AddRange(
                    new Condition
                    {
                        ConditionName = "Hypertension",
                        PatientId = 1
                    },
                    new Condition
                    {
                        ConditionName = "Diabetic",
                        PatientId = 1
                    },
                    new Condition
                    {
                        ConditionName = "Heart Disease",
                        PatientId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
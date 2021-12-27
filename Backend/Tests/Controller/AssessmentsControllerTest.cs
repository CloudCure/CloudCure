using System;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models.Diagnosis;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class AssessmentsControllerTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public AssessmentsControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = AssessmentControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = GetAssessment();

            var result = controller.Add(assessment);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnExceptionWithInvalidData()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var assessment = GetAssessment();

                var entry = controller.Add(assessment);
                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldReturnBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);
                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var assessment = repo.GetById(1);

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
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var result = controller.Delete(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldUpdateAssessment()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var assessment = GetAssessment();

                var result = controller.Update(1, assessment);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = GetAssessment();

            var entry = controller.Add(assessment);
            var results = controller.Update(-1, null);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldGetAssessmentById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = GetAssessment();

            var entry = controller.Add(assessment);
            var results = controller.GetById(-1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(400, okResponse.StatusCode);
        }

        [Fact]
        public void GetByPatientIdShouldReturnOk()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var result = controller.GetByDiagnosisId(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        public void GetByPatientIdShouldReturnBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repo = new AssessmentRepository(context);
                var controller = new AssessmentController(repo);

                var result = controller.GetByDiagnosisId(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private static Assessment GetAssessment()
        {
            return new Assessment
            {
                Id = 1,
                DiagnosisId = 1,
                PainAssessment = "asdfas",
                PainScale = 2,
                ChiefComplaint = "dfdssdf",
                HistoryOfPresentIllness = "dssdfs",
            };
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Assessments.AddRange(
                    new Assessment
                    {
                        DiagnosisId = 1,
                        PainAssessment = "asdfas",
                        PainScale = 2,
                        ChiefComplaint = "dfdssdf",
                        HistoryOfPresentIllness = "dssdfs",
                    },
                    new Assessment
                    {
                        DiagnosisId = 2,
                        PainAssessment = "asdfas",
                        PainScale = 2,
                        ChiefComplaint = "dfdssdf",
                        HistoryOfPresentIllness = "dssdfs",
                    });

                context.SaveChanges();
            }
        }
    }
}
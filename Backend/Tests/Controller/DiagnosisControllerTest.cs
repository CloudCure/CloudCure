using System;
using System.Collections.Generic;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class DiagnosisControllerTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public DiagnosisControllerTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = diagnosisControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void CreateReturnsOkDiagnosis()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = GetDiagnosis();

            var result = controller.Add(diagnosis);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllReturnsOKDiagnosis()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldReturnOKDiagnosis()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.Delete(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKDiagnosis()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = GetDiagnosis();
            diagnosis.IsFinalized = false;

            var entry = controller.Add(diagnosis);
            var result = controller.Update(2, diagnosis);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetbyPatientIdWithNavShouldReturnOK()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.GetByPatientIdWithNav(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetbyDiagnosisWithNavShouldReturnOK()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var results = controller.GetAllDiagnosisByPatientIdWithNav(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);
                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void CreateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.Delete(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByPatientIdWithNavShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.GetByPatientIdWithNav(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllDiagnosisByPatientIdWithNavShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                var controller = new DiagnosisController(repo);

                var result = controller.GetAllDiagnosisByPatientIdWithNav(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private Models.Diagnosis.Diagnosis GetDiagnosis()
        {
            Models.Diagnosis.Diagnosis d = new Models.Diagnosis.Diagnosis
            {
                PatientId = 1,
                EncounterDate = new DateTime(2021, 12, 27),
                Vitals = new Vitals
                {
                    DiagnosisId = 1,
                    Systolic = 120,
                    Diastolic = 80,
                    OxygenSat = 96.5,
                    HeartRate = 70,
                    RespiratoryRate = 12,
                    Temperature = 98.6,
                    Height = 75,
                    Weight = 145
                },
                Assessment = new Assessment
                {
                    DiagnosisId = 1,
                    PainAssessment = "asdfas",
                    PainScale = 2,
                    ChiefComplaint = "dfdssdf",
                    HistoryOfPresentIllness = "dssdfs"
                },
                DoctorDiagnosis = "He's fine",
                RecommendedTreatment = "Live life",
                IsFinalized = true
            };

            return d;
        }
        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Diagnoses.Add(GetDiagnosis());
                context.SaveChanges();
            }
        }
    }
}
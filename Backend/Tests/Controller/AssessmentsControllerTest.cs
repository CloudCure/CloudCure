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
    public class AssessmentsControllerTest
    {
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = new Assessment
            {
                PatientId = 1,
                ChiefComplaint = "Sore throat",
                PainAssessment = "throat",
                PainScale = 7,
                EncounterDate = new DateTime(2021, 12, 17)
            };

            var result = controller.Add(assessment);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = new Assessment
            {
                PatientId = 1,
                ChiefComplaint = "Sore throat",
                PainAssessment = "throat",
                PainScale = 7,
                EncounterDate = new DateTime(2021, 12, 17)
            };

            var entry = controller.Add(assessment);
            var result = controller.GetAll();
            var  okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = new Assessment
            {
                PatientId = 1,
                ChiefComplaint = "Sore throat",
                PainAssessment = "throat",
                PainScale = 7,
                EncounterDate = new DateTime(2021, 12, 17)
            };

            var entry = controller.Add(assessment);
            var result = controller.Delete(1);
            var  okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldUpdateAssessment()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = new Assessment
            {
                PatientId = 1,
                ChiefComplaint = "Sore throat",
                PainAssessment = "throat",
                PainScale = 7,
                EncounterDate = new DateTime(2021, 12, 17)
            };

            var entry = controller.Add(assessment);
            assessment.PainScale = 5;
            var result = controller.Update(1, assessment);
            var  okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldGetAssessmentById()
        {
            var repository = new Mock<IAssessmentRepository>();
            var controller = new AssessmentController(repository.Object);

            var assessment = new Assessment
            {
                PatientId = 1,
                ChiefComplaint = "Sore throat",
                PainAssessment = "throat",
                PainScale = 7,
                EncounterDate = new DateTime(2021, 12, 17)
            };

            var entry = controller.Add(assessment);
            var result = controller.GetById(1);
            var  okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }
    }
}

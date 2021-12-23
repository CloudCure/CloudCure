using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;


namespace Tests.Controller
{
    public class DiagnosisControllerTest
    {
        [Fact]
        public void CreateReturnsOkDiagnosis()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
               EncounterDate = DateTime.Now,
               DoctorDiagnosis = "dfsdfsd",
               RecommendedTreatment = "dfsdfsd"
            };

            var result = controller.Add(diagnosis);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllReturnsOKDiagnosis()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
                EncounterDate = DateTime.Now,
                DoctorDiagnosis = "dfsdfs",
                RecommendedTreatment = "dsfdf"
            };

            var entry = controller.Add(diagnosis);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
         public void DeleteShouldReturnOKDiagnosis()
        {
            var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
                EncounterDate = DateTime.Now,
                DoctorDiagnosis = "dfsdfs",
                RecommendedTreatment = "dsfdf"
            };

            var entry = controller.Add(diagnosis);

            var result = controller.Delete(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
        public void UpdateShouldReturnOKDiagnosis()
        {
             var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
                EncounterDate = DateTime.Now,
                DoctorDiagnosis = "dfsdfs",
                RecommendedTreatment = "dsfdf"
            };

            var entry = controller.Add(diagnosis);
            var result = controller.Update(1, diagnosis);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

        [Fact]
        public void GetbyPatientIdWithNavShouldReturnOK()
        {
             var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
                EncounterDate = DateTime.Now,
                DoctorDiagnosis = "dfsdfs",
                RecommendedTreatment = "dsfdf"
            };

            var entry = controller.Add(diagnosis);
            var results = controller.GetByPatientIdWithNav(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetbyDiagnosisWithNavShouldReturnOK()
        {
             var repository = new Mock<IDiagnosisRepository>();
            var controller = new DiagnosisController(repository.Object);

            var diagnosis = new Models.Diagnosis.Diagnosis
            {
                EncounterDate = DateTime.Now,
                DoctorDiagnosis = "dfsdfs",
                RecommendedTreatment = "dsfdf"
            };

            var entry = controller.Add(diagnosis);
            var results = controller.GetAllDiagnosisByPatientIdWithNav(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }
    }
}
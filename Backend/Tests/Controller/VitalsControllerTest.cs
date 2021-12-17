using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class VitalsControllerTest
    {
        [Fact]
        public void CreateReturnsOkVitals()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var vital = new Vitals
            {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Tempature = 98.6,
                        Height = 75,
                        Weight = 145,
            };

            var result = controller.Add(vital);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

         [Fact]
        public void GetAllReturnsOKVitals()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

           var vital = new Vitals
            {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Tempature = 98.6,
                        Height = 75,
                        Weight = 145,
            };

            var entry = controller.Add(vital);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }

         [Fact]
        public void DeleteShouldReturnOKVital()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

            var vital = new Vitals
            {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Tempature = 98.6,
                        Height = 75,
                        Weight = 145,
            };

            var entry = controller.Add(vital);

            var result = controller.Delete(vital);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }
        [Fact]
        public void UpdateShouldReturnOKVitals()
        {
            var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

           var vital = new Vitals
            {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Tempature = 98.6,
                        Height = 75,
                        Weight = 145,
            };

            var entry = controller.Add(vital);
            var result = controller.Update(1 , vital);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
            
         }

        [Fact]
         public void GetbyIdShouldReturnOKGetVitalsById()
         {
             var repository = new Mock<IVitalsRepository>();
            var controller = new VitalsController(repository.Object);

              var vital = new Vitals
            {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Tempature = 98.6,
                        Height = 75,
                        Weight = 145,
            };

            var entry = controller.Add(vital);
            var results = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
         }

    }
}
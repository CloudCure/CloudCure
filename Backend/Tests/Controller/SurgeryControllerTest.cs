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
    public class SurgeryControllerTest
    {
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
        public void GetAllReturnsOKSurgery()
        {
             var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            var surgery = new Surgery
            {
                PatientId = 1,
                SurgeryName = "Right Knee"
            };

            var entry = controller.Add(surgery);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

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
        public void UpdateShouldReturnOKAllergy()
        {
             var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            var surgery = new Surgery
            {
                PatientId = 1,
                SurgeryName = "Right Knee"
            };

            var entry = controller.Add(surgery);
            var result = controller.Update(1 , surgery);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
            
         }
    }
}
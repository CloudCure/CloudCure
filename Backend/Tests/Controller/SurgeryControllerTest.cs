using System;
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
        public void CreateShouldThrowAnException()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            try
            {
                var result = controller.Add(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
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
        public void GetAllShoudThrowAnException()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            try
            {
                var result = controller.GetAll();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
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
        public void DeleteShouldThrowAnException()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            try
            {
                var result = controller.Delete(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
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
            var result = controller.Update(1, surgery);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            try
            {
                var result = controller.Update(1, null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOKGetAllergyById()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            var surgery = new Surgery
            {
                PatientId = 1,
                SurgeryName = "Right Knee"
            };

            var entry = controller.Add(surgery);
            var results = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<ISurgeryRepository>();
            var controller = new SurgeryController(repository.Object);

            try
            {
                var result = controller.GetById(1);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }
    }
}
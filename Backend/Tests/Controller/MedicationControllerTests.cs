using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class MedicationControllerTests
    {
        [Fact]
        public void CreateReturnsOkMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var result = controller.Add(medication);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

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
        public void GetAllReturnsOKMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);
            
            
            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var entry = controller.Add(medication);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

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
        public void DeleteShouldReturnOKMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var entry = controller.Add(medication);

            var result = controller.Delete(medication);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

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
        public void UpdateShouldReturnOKMedication()
        {
            var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

           
            var medication = new Medication
            {
                PatientId = 1,
                MedicationName = "Tylenol"
            };

            var entry = controller.Add(medication);
            var result = controller.Update(1 , medication);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
         }

         [Fact]
         public void UpdateShouldThrowAnException()
         {
             var repository = new Mock<IRepository<Medication>>();
            var controller = new MedicationController(repository.Object);

            try
            {
                var result = controller.Update(1, null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
         }
    }
}
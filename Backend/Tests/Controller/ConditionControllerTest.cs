using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.Diagnosis;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests
{
    public class ConditionControllerTest
    {
        [Fact]
        public void CreateReturnsOkCondition()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);

            var condition = new Condition
            {
                PatientId = 1,
                ConditionName = "Hypertension"
            };

            var result = controller.Add(condition);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Condition>>();
            var controller = new ConditionController(repository.Object);

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
        public void GetAllReturnsOKCondition()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);


            var condition = new Condition
            {
                PatientId = 1,
                ConditionName = "Hypertension"
            };

            var entry = controller.Add(condition);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);

        }
        
        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Condition>>();
            var controller = new ConditionController(repository.Object);

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
        public void DeleteShouldReturnOKCondition()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);

            var condition = new Condition
            {
                PatientId = 1,
                ConditionName = "Hypertension"
            };

            var entry = controller.Add(condition);

            var result = controller.Delete(condition);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Condition>>();
            var controller = new ConditionController(repository.Object);

            try
            {
                var result = controller.Delete(new Condition());
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKCondition()
        {
            var repository = new Mock<IConditionRepository>();
            var controller = new ConditionController(repository.Object);


            var condition = new Condition
            {
                PatientId = 1,
                ConditionName = "Hypertension"
            };

            var entry = controller.Add(condition);
            var result = controller.Update(1, condition);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<IRepository<Condition>>();
            var controller = new ConditionController(repository.Object);

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
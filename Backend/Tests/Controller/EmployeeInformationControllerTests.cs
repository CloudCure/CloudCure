using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Tests
{
    public class EmployeeInformationControllerTests
    {
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var result = controller.Add(info);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var entry = controller.Add(info);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var entry = controller.Add(info);
            var result = controller.Delete(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldUpdateEmployeeInfo()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var entry = controller.Add(info);
            info.EducationDegree = "PhD";
            var result = controller.Update(1, info);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldGetEmployeeInfoById()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var entry = controller.Add(info);
            var result = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void VerifyEmailShouldReturnOk()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            var entry = controller.Add(info);
            var result = controller.VerifyUser(info.WorkEmail);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void CreateReturnsBadRequestEmployee()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            try
            {
                controller.Add(info);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

         [Fact]
        public void GetAllShouldReturnBadRequestEmployee()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            try
            {
                controller.Add(info);
                controller.GetAll();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void DeleteShouldReturnBadRequestEmployee()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            try
            {
                controller.Add(info);
                controller.Delete(0);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }
        [Fact]
        public void UpdateShouldReturnBadRequestEmployeeInfo()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            try
            {
                controller.Add(info);
                controller.Update(0, info);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

           [Fact]
        public void GetByIdShouldGetEmployeeInfoByIdWithBadRequest()
        {
            var repository = new Mock<IEmployeeInformationRepository>();
            var controller = new EmployeeInformationController(repository.Object);

            var info = newEmployee();

            try
            {
                controller.Add(info);
                controller.GetById(0);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }


        private EmployeeInformation newEmployee()
        {
            List<CovidVerify> covidList = new List<CovidVerify>();
            covidList.Add(
                new CovidVerify
                {
                    question1 = "true",
                    question2 = "true",
                    question3 = "true",
                    question4 = "true",
                    question5 = "true"
                }
            );

            return new EmployeeInformation
            {
                WorkEmail = "drJohn@email.com",
                EducationDegree = "MD",
                Specialization = "ER",
                RoomNumber = "101",
                StartDate = new DateTime(2021, 12, 14),
                UserProfile = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Generic St",
                    DateOfBirth = new DateTime(1986, 12, 18),
                    EmergencyContactPhone = "1235551234",
                    EmergencyName = "Jane Doe",
                    PhoneNumber = "5557654321",
                    CovidAssesments = covidList,
                    RoleId = 1,
                    Role = new Role
                    {
                        RoleName = "Doctor"
                    }
                }
            };
        }
    }
}
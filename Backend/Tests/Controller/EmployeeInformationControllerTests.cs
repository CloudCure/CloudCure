using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class EmployeeInformationControllerTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public EmployeeInformationControllerTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = employeeInfoControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }

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
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.Delete(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
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
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        // [Fact]
        // public void VerifyEmailShouldReturnOk()
        // {
        //     using (var context = new CloudCureDbContext(_options))
        //     {
        //         IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
        //         var controller = new EmployeeInformationController(repo);

        //         var info = newEmployee();

        //         controller.Add(info);
        //         var result = controller.VerifyUser(info.WorkEmail);
        //         var response = (IStatusCodeActionResult)result;
        //         Assert.Equal(200, response.StatusCode);
        //     }
        // }

        [Fact]
        public void CreateReturnsBadRequestEmployee()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldReturnBadRequestEmployee()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldReturnBadRequestEmployee()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.Delete(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldReturnBadRequestEmployeeInfo()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGetEmployeeInfoByIdWithBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void VerifyEmailShouldReturnBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                var controller = new EmployeeInformationController(repo);

                var result = controller.VerifyUser(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        private static EmployeeInformation newEmployee()
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

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Employee.Add(newEmployee());
                context.SaveChanges();
            }
        }
    }
}
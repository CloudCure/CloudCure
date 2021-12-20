using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Controllers;

namespace Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IUserRepository>();
            var controller = new UserController(repository.Object);

            var user = newUser();

            var result = controller.Add(user);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            var repository = new Mock<IUserRepository>();
            var controller = new UserController(repository.Object);

            var user = newUser();

            var entry = controller.Add(user);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            var repository = new Mock<IUserRepository>();
            var controller = new UserController(repository.Object);

            var user = newUser();

            var entry = controller.Add(user);
            var result = controller.Delete(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldUpdateUser()
        {
            var repository = new Mock<IUserRepository>();
            var controller = new UserController(repository.Object);

            var user = newUser();

            var entry = controller.Add(user);
            user.FirstName = "Fred";
            var result = controller.Update(1, user);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldGetUserById()
        {
            var repository = new Mock<IUserRepository>();
            var controller = new UserController(repository.Object);

            var user = newUser();

            var entry = controller.Add(user);
            var result = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        private User newUser()
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

            return new User
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
            };
        }
    }
}
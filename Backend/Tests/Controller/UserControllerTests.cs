using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class UserControllerTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public UserControllerTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = userControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        
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
        public void CreateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.Delete(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.Delete(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldUpdateUser()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var user = newUser();
                user.FirstName = "Fred";

                var result = controller.Update(1, user);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGetUserById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGiveBadRequest()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var controller = new UserController(repo);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private static User newUser()
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

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.Add(newUser());
                context.SaveChanges();
            }
        }
    }
}
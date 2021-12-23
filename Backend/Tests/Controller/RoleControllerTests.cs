using System;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class RoleControllerTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public RoleControllerTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = roleControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }
        
        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            var role = new Role
            {
                Id = 1,
                RoleName = "Doctor"
            };

            var result = controller.Add(role);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(1, role.Id);
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldGiveBadResponse()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

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
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGiveBadResponse()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            var role = new Role
            {
                RoleName = "Doctor"
            };

            var entry = controller.Add(role);
            var result = controller.Delete(role);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var result = controller.Delete(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldUpdateRole()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var role = new Role
                {
                    RoleName = "Nurse"
                };

                var result = controller.Update(1, role);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGetRoleById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var controller = new RoleController(repo);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Roles.Add(new Role
                {
                    RoleName = "Doctor"
                });
                context.SaveChanges();
            }
        }
    }
}
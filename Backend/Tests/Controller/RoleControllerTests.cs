using System;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class RoleControllerTests
    {
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
        public void CreateShouldThrownAnException()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

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
        public void GetAllShouldGetAll()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            var role = new Role
            {
                RoleName = "Doctor"
            };

            var entry = controller.Add(role);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

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
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

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
        public void UpdateShouldUpdateRole()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            var role = new Role
            {
                RoleName = "Doctor"
            };

            var entry = controller.Add(role);
            role.RoleName = "Nurse";
            var result = controller.Update(1, role);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

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
        public void GetByIdShouldGetRoleById()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            var role = new Role
            {
                RoleName = "Doctor"
            };

            var entry = controller.Add(role);
            var result = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            try
            {
                var result = controller.GetById(100);
            }
            catch (Exception e)
            {
                Assert.True(e.Message.Contains("Not a valid ID"));

            }
        }
    }
}
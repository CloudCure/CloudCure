using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        public void CreateShouldThrowExceptionWithInvalidInput()
        {
            var repository = new Mock<IRoleRepository>();
            var controller = new RoleController(repository.Object);

            //var result = controller.Add(null);
            //var response = (IStatusCodeActionResult)result;
            //Assert.Equal(400, response.StatusCode);
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
    }
}
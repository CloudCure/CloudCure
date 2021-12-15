using System;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace Tests
{
    public class UserRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public UserRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = User.db; Foreign Keys=False").Options;
            Seed();
        }


        [Fact]
        public void GetUserShouldGetAllOfUser()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                var result = repo.GetUserById(1);

                Assert.NotNull(result);
                Assert.Equal("John", result.FirstName);
                Assert.Equal("Doctor", result.Role.RoleName);
                Assert.Equal(true, result.CovidAssesments[0].question1);
            }
        }

        public void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<CovidVerify> covidList = new List<CovidVerify>();
                covidList.Add(
                    new CovidVerify
                    {
                        question1 = true,
                        question2 = true,
                        question3 = true,
                        question4 = true,
                        question5 = true
                    }
                );

                context.Users.Add(
                    new User
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Address = "123 Street St",
                        DateOfBirth = new DateTime(1986, 12, 18),
                        EmergencyName = "Mom",
                        EmergencyContactPhone = "5551234567",
                        PhoneNumber = "5557654321",
                        RoleId = 1,
                        CovidAssesments = covidList,
                        Role = new Role
                        {
                            RoleName = "Doctor"
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;

using System.Linq;

namespace Tests
{
    public class RepoTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public RepoTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Repository.db; Foreign Keys=False").Options;
            Seed();
        }
        [Fact]
        public void GetByCovidIdShouldPopulateCovidId()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                var result = repository.GetById(1);

                Assert.Equal(true, result.question1);
            }
        }

        [Fact]
        public void CreateCovidShouldCreateCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                CovidVerify newCovid = new()
                {
                    question1 = false,

                };
                repository.Create(newCovid);
                repository.Save();

                Assert.Equal(newCovid.question1, repository.GetById(3).question1);

            }
        }

        [Fact]
        public void GetAllCovidShouldReturnAllCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);

                var testList = repository.GetAll();

                Assert.True(testList.Any());
            }
        }

        [Fact]
        public void UpdateCovidshouldUpdateCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                var testCovid = repository.GetById(1);
                testCovid.question1 = false;
                repository.Update(testCovid);
                repository.Save();

                Assert.Equal(false, testCovid.question1);
            }
        }

        [Fact]
        public void DeleteCovidshouldDeleteCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                var testCovid = repository.GetById(1);
                repository.Delete(testCovid);
                repository.Save();

                var result = repository.GetAll();

                Assert.Single(result);
            }
        }



        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Roles.AddRange(
                    new Role
                    {
                        RoleName = "Doc"
                    }
                );
                context.SaveChanges();


                context.Users.AddRange(
                    new User
                    {
                        FirstName = "johnny",
                        LastName = "appleseed",
                        PhoneNumber = "123-456-7890",
                        Address = "123 Place Ln.",
                        DateOfBirth = new DateTime(),
                        EmergencyName = "help!",
                        EmergencyContactPhone = "911-911-9110",
                        RoleId = 1
                    }
                );
                context.SaveChanges();

                context.CovidAssessments.AddRange(
                    new CovidVerify
                    {
                        question1 = true,
                        question2 = true,
                        question3 = false,
                        question4 = false,
                        question5 = true

                    },
                    new CovidVerify
                    {
                        question1 = true,
                        question2 = true,
                        question3 = false,
                        question4 = false,
                        question5 = true
                    }
                );


                context.SaveChanges();
            }
        }
    }
}
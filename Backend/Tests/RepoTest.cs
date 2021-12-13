using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;
using DataAccess;
using System.Linq;

namespace Tests
{
    public class RepoTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public RepoTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Repository.db").Options;
                    Seed();
        }
        [Fact]
        public void GetByCovidIdShouldPopulateCovidId()
        {
           using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                var result = repository.GetByPrimaryKey(1);


                Assert.Equal(1, result.UsersId);
                Assert.Equal(true, result.covidChoice);
            }
        }

         [Fact]
        public void CreateCovidShouldCreateCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                CovidVerify newCovid = new ()
                {
                    UsersId = 3,
                    covidChoice = false,
                    
                };
                repository.Create(newCovid);
                repository.Save();

                Assert.Equal(newCovid.covidChoice, repository.GetByPrimaryKey(3).covidChoice);
                
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
                var testCovid = repository.GetByPrimaryKey(1);
                testCovid.covidChoice = false;
                repository.Update(testCovid);
                repository.Save();

                Assert.Equal(false, testCovid.covidChoice);
            }
        }

         [Fact]
        public void DeleteCovidshouldDeleteCovid()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRepository<CovidVerify> repository = new Repository<CovidVerify>(context);
                var testCovid = repository.GetByPrimaryKey(1);
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

                context.CovidAssessments.AddRange(
                    new CovidVerify
                    {
                        UsersId = 1,
                        covidChoice = true

                    },
                    new CovidVerify
                    {
                        UsersId = 2,
                        covidChoice = true
                    }
                );
               

                context.SaveChanges();
            }
        }
    }
}
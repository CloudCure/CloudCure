using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;

namespace Tests
{
    public class CovidRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public CovidRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = CovidRepo.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void GetCovidInfoForUserShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ICovidRepository repo = new CovidRepository(context);
                var results = repo.GetCovidInfoForUser(1);

                Assert.NotNull(results);
                Assert.Equal("true", results.question1);
                Assert.Equal("true", results.question2);
                Assert.Equal(1, results.UserId);
                Assert.Equal(1, results.Id);
            }
        }

        public void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CovidVerify covid = new CovidVerify
                {
                    question1 = "true",
                    question2 = "true",
                    question3 = "true",
                    question4 = "true",
                    question5 = "true",
                    UserId = 1
                };

                context.CovidAssessments.Add(covid);
                context.SaveChanges();
            }
        }
    }
}
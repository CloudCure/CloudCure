using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Xunit;

namespace Tests
{
    public class ConditionRepoTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public ConditionRepoTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = ConditionTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByConditionhouldReturnExpectedResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                List<Condition> results = repo.SearchByCondition("Hypertension").ToList();

                Assert.NotEmpty(results);
                Assert.Equal(1, results[0].PatientId);
            }
        }

        [Fact]
        public void SearchByPatientIdShouldReturnExpectedResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);
                List<Condition> results = repo.SearchByPatientId(1).ToList();

                Assert.NotEmpty(results);
                Assert.Equal("Diabetic", results[1].ConditionName);
            }
        }

        [Fact]
        public void SearchByConditionShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repo.SearchByCondition("fail"));
            }
        }

        [Fact]
        public void SearchByPatientIdShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IConditionRepository repo = new ConditionRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repo.SearchByPatientId(-1));
            }
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Conditions.AddRange(
                    new Condition
                    {
                        ConditionName = "Hypertension",
                        PatientId = 1
                    },
                    new Condition
                    {
                        ConditionName = "Diabetic",
                        PatientId = 1
                    },
                    new Condition
                    {
                        ConditionName = "Heart Disease",
                        PatientId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
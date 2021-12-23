using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models.Diagnosis;
using Data;

namespace Tests
{
    public class AllergyRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public AllergyRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = AllergyTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByAllergyShouldReturnExpectedResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                List<Allergy> results = repo.SearchByAllergy("Nuts").ToList();

                Assert.NotEmpty(results);
                Assert.Equal(1, results[0].PatientId);
            }
        }

        [Fact]
        public void SearchByPatientIdShouldReturnExpectedResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);
                List<Allergy> results = repo.SearchByPatientId(1).ToList();

                Assert.NotEmpty(results);
                Assert.Equal(3, results.Count);
                Assert.Equal("Nuts", results[1].AllergyName);
            }
        }

        [Fact]
        public void SearchByPatientIdShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repo.SearchByPatientId(-1));
            }
        }

        [Fact]
        public void SearchByAllergyShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repo = new AllergyRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repo.SearchByAllergy("can'tfindme"));
            }
        }


        private void Seed()

        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Allergies.AddRange(
                    new Allergy
                    {
                        AllergyName = "Gluten",
                        PatientId = 1
                    },
                    new Allergy
                    {
                        AllergyName = "Nuts",
                        PatientId = 1
                    },
                    new Allergy
                    {
                        AllergyName = "Strawberries",
                        PatientId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
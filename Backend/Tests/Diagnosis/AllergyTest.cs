using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;
using System.Linq;
using Models.Diagnosis;
using System.Collections.Generic;

namespace Tests
{
    public class AllergyTest
    {

        readonly DbContextOptions<CloudCureDbContext> _options;

        public AllergyTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Allergy.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByPatientIdShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repository = new AllergyRepository(context);
                var Allergy = repository.SearchByPatientId(1);

                Assert.NotEmpty(Allergy);
            }
        }

        [Fact]
        public void SearchByPatientIdShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repository = new AllergyRepository(context);

               Assert.Throws<KeyNotFoundException>(() => repository.SearchByPatientId(3));
            }
        }

        [Fact]
        public void SearchByAllergyShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAllergyRepository repository = new AllergyRepository(context);
                var allergy = repository.SearchByAllergy("Dogs");

                Assert.NotEmpty(allergy);
            }
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Patients.AddRange(
                    new Patient
                    {
                        Allergies = new List<Allergy>{
                            new Allergy
                            {
                                PatientId = 1,
                                AllergyName = "Dogs"

                            },
                            new Allergy
                            {
                                PatientId = 1,
                                AllergyName = "Haldol"
                            }
                        }
                    }
                );

                context.SaveChanges();

            }



        }
    }
}


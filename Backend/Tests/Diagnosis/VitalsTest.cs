using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Xunit;

namespace Tests
{
    public class VitalsTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;
        
        public VitalsTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = vitals.db; Foreign Keys=False").Options;
            Seed();
        }


        [Fact]
        public void SearchByPatientIdShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IVitalsRepository repository = new VitalsRepository(context);
                var Vitals = repository.SearchByPatientId(1);

                Assert.NotNull(Vitals);
                Assert.Equal(98.6, Vitals.Temperature);
            }
            
            // Given
        
            // When
        
            // Then
        }
         [Fact]
        public void GetbyIdShouldReturnVitalsId()
            {
                using ( var context = new CloudCureDbContext(_options))
                {
                    IVitalsRepository repository = new VitalsRepository(context);
                    var assessment = repository.GetById(1);

                    Assert.Equal(1, assessment.Id);
                }
            }
        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Vitals.AddRange(
                    new Vitals
                    {
                        PatientId = 1,
                        Systolic = 120,
                        Diastolic = 80,
                        OxygenSat = 96.5,
                        HeartRate = 70,
                        RespiratoryRate = 12,
                        Temperature = 98.6,
                        Height = 75,
                        Weight = 145,
                        //EncounterDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

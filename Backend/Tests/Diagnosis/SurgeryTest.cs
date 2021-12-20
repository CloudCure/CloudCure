using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Xunit;

namespace Tests.Diagnosis
{
    public class SurgeryTest
    {
         readonly DbContextOptions<CloudCureDbContext> _options;

        public SurgeryTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Surgery.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByPatientIdShouldReturnResultsSurgery()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repository = new SurgeryRepository(context);
                var surgery = repository.SearchByPatientId(1);

                Assert.NotNull(surgery);
                
            }
            
            
        }

           void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Surgeries.AddRange(
                    new Surgery
                    {
                        PatientId = 1,
                       SurgeryName = "Right Knee"
                    }
                );

                context.SaveChanges();

            }



        }
    }
}
using System.Collections.Generic;
using System;
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

        [Fact]
        public void GetbyIdShouldReturnSurgeryId()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repository = new SurgeryRepository(context);
                var surgery = repository.GetById(1);

                Assert.Equal(1, surgery.Id);
            }
        }

        [Fact]
        public void SearchByPatientIdShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                ISurgeryRepository repo = new SurgeryRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repo.SearchByPatientId(-1));
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
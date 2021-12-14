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
    public class AssessmentTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public AssessmentTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = AssessmentTest.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByPatientIdShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repository = new AssessmentRepository(context);
                var patient = repository.SearchByPatientId(1);

                Assert.NotNull(patient);
            }
        }
        [Fact]
        public void SearchByPatientIdShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IAssessmentRepository repository = new AssessmentRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repository.SearchByPatientId(3));
            }
        }


        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Assessments.AddRange(
                    new Assessment
                    {
                        PatientId = 1,
                        PainAssessment = "asdfas",
                        PainScale = 2,
                        ChiefComplaint = "dfdssdf",
                        HistoryOfPresentIllness = "dssdfs",


                    },
                            new Assessment
                            {
                                PatientId = 2,
                                PainAssessment = "asdfas",
                                PainScale = 2,
                                ChiefComplaint = "dfdssdf",
                                HistoryOfPresentIllness = "dssdfs"


                            });


                context.SaveChanges();

            }



        }
    }
}
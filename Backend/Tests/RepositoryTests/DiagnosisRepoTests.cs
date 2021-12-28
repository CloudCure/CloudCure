using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Models;
using Xunit;

namespace Tests
{
    public class DiagnosisRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public DiagnosisRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = DiagnosisRepoTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void GetByPatientIdWithNavShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                Models.Diagnosis.Diagnosis test = repo.GetByPatientIdWithNav(1);

                Assert.NotNull(test);
            }
        }

        [Fact]
        public void GellAllWithNavShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                List<Models.Diagnosis.Diagnosis> results = repo.GetAllDiagnosisByPatientIdWithNav(1).ToList();

                Assert.NotEmpty(results);
            }
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Models.Diagnosis.Diagnosis test = new Models.Diagnosis.Diagnosis();
                DateTime date = new DateTime(2021, 12, 22);
                Vitals v = new Vitals
                {
                    Diastolic = 70,
                    Systolic = 120,
                    HeartRate = 70,
                    Height = 75,
                    Weight = 200,
                    OxygenSat = 98.2,
                    Temperature = 97.2,
                    RespiratoryRate = 14
                };
                Assessment a = new Assessment
                {
                    PainAssessment = "asdfas",
                    PainScale = 2,
                    ChiefComplaint = "dfdssdf",
                    HistoryOfPresentIllness = "dssdfs"
                };
                string docDiagnosis = "He's fine";
                string treatment = "Live life";
                bool finalized = true;

                test.Id = 1;
                test.PatientId = 1;
                test.EncounterDate = date;
                test.Vitals = v;
                test.Assessment = a;
                test.DoctorDiagnosis = docDiagnosis;
                test.RecommendedTreatment = treatment;
                test.IsFinalized = finalized;

                context.Add(test);
                context.SaveChanges();
            }
        }
    }
}
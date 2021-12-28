using System;
using Xunit;
using Models.Diagnosis;

namespace Tests
{
    public class DiagnosisModelTests
    {
        [Fact]
        public void DiagnosisModelShouldSetValidData()
        {
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

            test.Id = 1;
            test.PatientId = 1;
            test.EncounterDate = date;
            test.Vitals = v;
            test.Assessment = a;
            test.DoctorDiagnosis = docDiagnosis;
            test.RecommendedTreatment = treatment;
            test.IsFinalized = true;

            Assert.Equal(1, test.Id);
            Assert.Equal(1, test.PatientId);
            Assert.Equal(date, test.EncounterDate);
            Assert.Equal(v, test.Vitals);
            Assert.Equal(a, test.Assessment);
            Assert.Equal(docDiagnosis, test.DoctorDiagnosis);
            Assert.Equal(treatment, test.RecommendedTreatment);
            Assert.True(test.IsFinalized);
        }
    }
}
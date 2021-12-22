using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;
using Xunit;

namespace Tests
{
    public class MedicationModelTest
    {
        [Fact]
        public void MedicationNameShouldSetValidData()
        {
            Medication _medicationNameTest = new Medication();
            string medicationname = "tylenol";
          

            _medicationNameTest.MedicationName = medicationname;


            Assert.Equal(_medicationNameTest.MedicationName, medicationname);
        }

        [Fact]
        public void MedicationPatientIdShouldSetValidData()
        {
            Medication _patientIdTest = new Medication();
            int patientId = 1;
          

            _patientIdTest.PatientId = patientId;


            Assert.Equal(_patientIdTest.PatientId, patientId);
        }

        [Fact]
        public void MedicationIdShouldSetValidData()
        {
            Medication _idTest = new Medication();
            int Id = 1;
          

            _idTest.Id = Id;


            Assert.Equal(_idTest.Id, Id);
            Assert.NotNull(_idTest);
        }
    }
}

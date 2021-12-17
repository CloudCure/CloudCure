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
    }
}

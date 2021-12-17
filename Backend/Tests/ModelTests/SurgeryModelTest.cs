using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;
using Xunit;

namespace Tests
{
    public class SurgeryModelTest
    {
        [Fact]
        public void SurgeryNameShouldSetValidData()
        {
            Surgery _surgeryNameTest = new Surgery();
            string surgeryname = "Knee";
          

            _surgeryNameTest.SurgeryName = surgeryname;


            Assert.Equal(_surgeryNameTest.SurgeryName, surgeryname);
        }
    }
}

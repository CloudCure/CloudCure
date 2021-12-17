using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;
using Xunit;

namespace Tests.ModelTests
{
    public class AllergyModelTest
    {
        [Fact]
        public void AllergyNameShouldSetValidData()
        {
            Allergy _allergyNameTest = new Allergy();
            string allergyname = "haldol";
          

            _allergyNameTest.AllergyName = allergyname;


            Assert.Equal(_allergyNameTest.AllergyName, allergyname);
        }

        



    }
}

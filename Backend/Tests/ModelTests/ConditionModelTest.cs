using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;
using Xunit;

namespace Tests.ModelTests
{
    public class ConditionModelTest
    {
        [Fact]
        public void ConditionNameShouldSetValidData()
        {
            Condition _conditionNameTest = new Condition();
            string conditionname = "Heart Problems";
          

            _conditionNameTest.ConditionName = conditionname;


            Assert.Equal(_conditionNameTest.ConditionName, conditionname);
        }
    }
}

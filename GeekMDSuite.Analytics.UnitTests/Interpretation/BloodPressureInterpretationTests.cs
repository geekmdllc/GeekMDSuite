using System;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Core;
using Xunit;
using Xunit.Sdk;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class BloodPressureInterpretationTests
    {
        [Fact]
        public void Given_NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BloodPressureInterpretation(null));
        }
        
        [Fact]
        public void GivenProperBloodPressure_ReturnsCorrectType()
        {
            var bpInterp = new BloodPressureInterpretation(BloodPressure.Build(175, 95));

            Assert.IsType<BloodPressureInterpretation>(bpInterp);
        }
        
        [Fact]
        public void GivenProperBloodPressure_ReturnsNonEmptyString()
        {
            var bpInterp = new BloodPressureInterpretation(BloodPressure.Build(175, 95));

            Assert.NotEmpty(bpInterp.ToString());
        }

    }
}
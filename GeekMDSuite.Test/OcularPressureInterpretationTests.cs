using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class OcularPressureInterpretationTests
    {
        [Theory]
        [InlineData(18, 18, OcularPressureClassification.Normal)]
        [InlineData(25, 18, OcularPressureClassification.OcularHypertension)]
        [InlineData(18, 25, OcularPressureClassification.OcularHypertension)]
        [InlineData(25, 25, OcularPressureClassification.OcularHypertension)]
        public void Classify_GivenValues_ReturnsExpectedClassification(int left, int right,
            OcularPressureClassification expectedClassification)
        {
            var ocularPressure = OcularPressure.Build(left, right);
            var classification = new OcularPressureInterpretation(ocularPressure).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void NullOcularPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OcularPressureInterpretation(null));
        }
    }
}
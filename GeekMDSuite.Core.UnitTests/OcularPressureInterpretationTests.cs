using System;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.Core.Procedures;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
{
    public class OcularPressureInterpretationTests
    {
        [Theory]
        [InlineData(18, 18, OcularPressureClassificationResult.Normal)]
        [InlineData(25, 18, OcularPressureClassificationResult.OcularHypertension)]
        [InlineData(18, 25, OcularPressureClassificationResult.OcularHypertension)]
        [InlineData(25, 25, OcularPressureClassificationResult.OcularHypertension)]
        public void Classify_GivenValues_ReturnsExpectedClassification(int left, int right,
            OcularPressureClassificationResult expectedClassificationResult)
        {
            var ocularPressure = OcularPressure.Build(left, right);
            var classification = new OcularPressureClassification(ocularPressure).Classification;
            
            Assert.Equal(expectedClassificationResult, classification);
        }

        [Fact]
        public void NullOcularPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OcularPressureClassification(null));
        }
    }
}
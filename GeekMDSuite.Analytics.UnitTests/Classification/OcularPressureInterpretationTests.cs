using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class OcularPressureInterpretationTests
    {
        [Theory]
        [InlineData(18, 18, OccularPressureClassificationResult.Normal)]
        [InlineData(25, 18, OccularPressureClassificationResult.OcularHypertension)]
        [InlineData(18, 25, OccularPressureClassificationResult.OcularHypertension)]
        [InlineData(25, 25, OccularPressureClassificationResult.OcularHypertension)]
        public void Classify_GivenValues_ReturnsExpectedClassification(int left, int right,
            OccularPressureClassificationResult expectedClassificationResult)
        {
            var ocularPressure = OccularPressure.Build(left, right);
            var classification = new OccularPressureClassification(ocularPressure).Classification;

            Assert.Equal(expectedClassificationResult, classification);
        }

        [Fact]
        public void NullOcularPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OccularPressureClassification(null));
        }
    }
}
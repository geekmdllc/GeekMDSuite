using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class PeripheralVisionInterpretationTests
    {
        [Theory]
        [InlineData(90, 90, PeripheralVisionClassificationResult.Normal)]
        [InlineData(55, 90, PeripheralVisionClassificationResult.Narrow)]
        [InlineData(90, 55, PeripheralVisionClassificationResult.Narrow)]
        [InlineData(55, 55, PeripheralVisionClassificationResult.Narrow)]
        public void Classification_GivenData_ReturnsCorretClassification(int left, int right, 
            PeripheralVisionClassificationResult expectedClassificationResult)
        {
            var pv = PeripheralVision.Build(left, right);
            var classification = new PeripheralVisionClassification(pv).Classification;
            
            Assert.Equal(expectedClassificationResult, classification);
        }

        [Fact]
        public void GivenNullPeripheralVision_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PeripheralVisionClassification(null));
        }
    }
}
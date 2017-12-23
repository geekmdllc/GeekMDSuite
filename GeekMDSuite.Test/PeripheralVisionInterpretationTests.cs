using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PeripheralVisionInterpretationTests
    {
        [Theory]
        [InlineData(90, 90, PeripheralVisionClassification.Normal)]
        [InlineData(55, 90, PeripheralVisionClassification.Narrow)]
        [InlineData(90, 55, PeripheralVisionClassification.Narrow)]
        [InlineData(55, 55, PeripheralVisionClassification.Narrow)]
        public void Classification_GivenData_ReturnsCorretClassification(int left, int right, 
            PeripheralVisionClassification expectedClassification)
        {
            var pv = PeripheralVision.Build(left, right);
            var classification = new PeripheralVisionInterpreation(pv).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void GivenNullPeripheralVision_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PeripheralVisionInterpreation(null));
        }
    }
}
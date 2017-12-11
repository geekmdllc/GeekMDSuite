using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PeripheralVisionInterpretationTests
    {
        [Fact]
        public void Classification_GivenNormalAnglesBothSides_ReturnsNormal()
        {
            var pv = new PeripheralVision(90, 85);
            var classification = new PeripheralVisionInterpreation(pv).Classification;
            
            Assert.Equal(PeripheralVisionClassification.Normal, classification);
        }
        [Fact]
        public void Classification_GivenLeftAngleReduced_ReturnsNarrow()
        {
            var pv = new PeripheralVision(60, 85);
            var classification = new PeripheralVisionInterpreation(pv).Classification;
            
            Assert.Equal(PeripheralVisionClassification.Narrow, classification);
        }
        
        [Fact]
        public void Classification_GivenRightAngleReduced_ReturnsNarrow()
        {
            var pv = new PeripheralVision(90, 55);
            var classification = new PeripheralVisionInterpreation(pv).Classification;
            
            Assert.Equal(PeripheralVisionClassification.Narrow, classification);
        }
        
        [Fact]
        public void Classification_GivenBothAnglesReduced_ReturnsNarrow()
        {
            var pv = new PeripheralVision(60, 55);
            var classification = new PeripheralVisionInterpreation(pv).Classification;
            
            Assert.Equal(PeripheralVisionClassification.Narrow, classification);
        }
    }
}
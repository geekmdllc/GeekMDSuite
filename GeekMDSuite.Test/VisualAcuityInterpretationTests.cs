using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class VisualAcuityInterpretationTests
    {
        [Fact]
        public void Classification_Given15ViewDistance_ReturnsNormal()
        {
            var classifcation = new VisualAcuityInterpretation(VisualAcuity.Build(15, 15, 15)).Classification;
            
            Assert.Equal(VisualAcuityClassification.Ideal, classifcation);
        }
        [Fact]
        public void Classification_Given20ViewDistance_ReturnsNormal()
        {
            var classifcation = new VisualAcuityInterpretation(VisualAcuity.Build(20, 20, 20)).Classification;
            
            Assert.Equal(VisualAcuityClassification.Normal, classifcation);
        }
        [Fact]
        public void Classification_Given200ViewDistance_ReturnsSevereVisionLoss()
        {
            var classifcation = new VisualAcuityInterpretation(VisualAcuity.Build(200, 200, 200)).Classification;
            
            Assert.Equal(VisualAcuityClassification.SevereLowVision, classifcation);
        }
        [Fact]
        public void Classification_Given1500ViewDistance_ReturnsNearTotalBlindness()
        {
            var classifcation = new VisualAcuityInterpretation(VisualAcuity.Build(1500, 200, 200)).Classification;
            
            Assert.Equal(VisualAcuityClassification.NearTotalBlindness, classifcation);
        }
    }
}
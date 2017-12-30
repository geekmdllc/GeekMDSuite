using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class VisualAcuityInterpretationTests
    {
        [Theory]
        [InlineData(15, 15, 15, VisualAcuityClassificationResult.Ideal)]
        [InlineData(15, 20, 15, VisualAcuityClassificationResult.Normal)]
        [InlineData(15, 15, 30, VisualAcuityClassificationResult.NearNormal)]
        [InlineData(15, 15, 70, VisualAcuityClassificationResult.ModerateLowVision)]
        [InlineData(15, 200, 15, VisualAcuityClassificationResult.SevereLowVision)]
        [InlineData(500, 15, 15, VisualAcuityClassificationResult.ProfoundLowVision)]
        [InlineData(1500, 15, 15, VisualAcuityClassificationResult.NearTotalBlindness)]
        public void Classification_GivenData_ReturnsCorrectClassification(int distance, int near, int both,
            VisualAcuityClassificationResult expectedClassificationResult)
        {
            var classifcation = new VisualAcuityClassification(VisualAcuity.Build(distance, near, both)).Classification;
            
            Assert.Equal(expectedClassificationResult, classifcation);
        }
    }
}
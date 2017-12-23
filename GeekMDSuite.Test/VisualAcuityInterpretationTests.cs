using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class VisualAcuityInterpretationTests
    {
        [Theory]
        [InlineData(15, 15, 15, VisualAcuityClassification.Ideal)]
        [InlineData(15, 20, 15, VisualAcuityClassification.Normal)]
        [InlineData(15, 15, 30, VisualAcuityClassification.NearNormal)]
        [InlineData(15, 15, 70, VisualAcuityClassification.ModerateLowVision)]
        [InlineData(15, 200, 15, VisualAcuityClassification.SevereLowVision)]
        [InlineData(500, 15, 15, VisualAcuityClassification.ProfoundLowVision)]
        [InlineData(1500, 15, 15, VisualAcuityClassification.NearTotalBlindness)]
        public void Classification_GivenData_ReturnsCorrectClassification(int distance, int near, int both,
            VisualAcuityClassification expectedClassification)
        {
            var classifcation = new VisualAcuityInterpretation(VisualAcuity.Build(distance, near, both)).Classification;
            
            Assert.Equal(expectedClassification, classifcation);
        }
    }
}
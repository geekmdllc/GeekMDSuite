using Xunit;

namespace GeekMDSuite.Test.FitnessTests
{
    public class FitTreadmillScoreTest
    {
        [Fact]
        public void Interpretation_GivenNegative150_ReturnsHighRisk()
        {
            var interpetation = FitTreadmillScore.Interpret(-150);
            
            Assert.Equal(FitTreadmillScoreInterpretation.HighRisk, interpetation);
        }
    }
}
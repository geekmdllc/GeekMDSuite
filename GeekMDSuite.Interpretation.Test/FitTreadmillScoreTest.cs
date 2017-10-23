using GeekMDSuite.Interpretation.Procedures;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class FitTreadmillScoreTest
    {
        [Fact]
        public void ReturnsCorrectInterpretation()
        {
            var interpetation = FitTreadmillScore.Interpret(-150);
            
            Assert.Equal(FitTreadmillScoreInterpretation.HighRisk, interpetation);
        }
    }
}
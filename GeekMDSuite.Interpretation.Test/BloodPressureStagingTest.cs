using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureStagingTest
    {
        [Fact]
        void ReturnsCorrectStage()
        {
            var bpStage = GeekMDSuite.Interpretation.BloodPressureStage.Interpret(133, 69, false);
            Assert.Equal(BloodPressureStages.PreHypertension, bpStage);
        }
    }
}
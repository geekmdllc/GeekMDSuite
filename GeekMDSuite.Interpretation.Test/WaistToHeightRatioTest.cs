using GeekMDSuite.Common;
using Xunit;  

namespace GeekMDSuite.Interpretation.Test
{
    public class WaistToHeightRatioTest
    {
        [Fact]
        public void Intepret_GivenMaleWith0point33_ReturnsExtremelySlim()
        {
            var result = WaistToHeightRatio.Interpret(Genders.NonBinaryXy, 0.33);
            Assert.Equal(WaistToHeightRatioCategorization.ExtremelySlim, result);
        }

        [Fact]
        public void Interpret_GivenFemaleWith0point33_ReturnsExtremelySlim()
        {
            var result = WaistToHeightRatio.Interpret(Genders.Female, 0.33);
            Assert.Equal(WaistToHeightRatioCategorization.ExtremelySlim, result);
        }
    }
}
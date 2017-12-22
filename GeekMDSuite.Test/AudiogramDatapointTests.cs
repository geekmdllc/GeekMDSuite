using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramDatapointTests
    {
        [Theory]
        [InlineData(15, HearingLoss.None)]
        [InlineData(30, HearingLoss.Mild)]
        [InlineData(55, HearingLoss.Moderate)]
        [InlineData(75, HearingLoss.Severe)]
        [InlineData(95, HearingLoss.Profound)]
        public void Classification_GivenADecibalValue_ReturnsExpectedClassification(int value, HearingLoss expectedClassification)
        {
            var result = AudiogramDatapoint.Build(value);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(expectedClassification, interp.Classification);
        }
    }
}
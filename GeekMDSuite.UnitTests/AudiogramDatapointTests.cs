using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.UnitTests
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
            var interp = new AudiogramDataPointClassification(result);
            
            Assert.Equal(expectedClassification, interp.Classification);
        }
    }
}
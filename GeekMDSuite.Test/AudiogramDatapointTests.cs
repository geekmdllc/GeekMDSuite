using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramDatapointTests
    {
        [Fact]
        public void Value_Given15_ReturnsNoHearingLoss()
        {
            var result = new AudiogramDatapoint(15);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(HearingLoss.None, interp.Classification);
        }
        [Fact]
        public void Value_Given30_ReturnsMildHearingLoss()
        {
            var result = new AudiogramDatapoint(30);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(HearingLoss.Mild, interp.Classification);
        }
        [Fact]
        public void Value_Given55_ReturnsModerateHearingLoss()
        {
            var result = new AudiogramDatapoint(55);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(HearingLoss.Moderate, interp.Classification);
        }
        [Fact]
        public void Value_Given75_ReturnsSevereHearingLoss()
        {
            var result = new AudiogramDatapoint(75);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(HearingLoss.Severe, interp.Classification);
        }
        [Fact]
        public void Value_Given95_ReturnsProfoundHearingLoss()
        {
            var result = new AudiogramDatapoint(95);
            var interp = new AudiogramDataPointInterpretation(result);
            
            Assert.Equal(HearingLoss.Profound, interp.Classification);
        }
    }
}
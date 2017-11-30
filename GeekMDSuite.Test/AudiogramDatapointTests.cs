using GeekMDSuite.Procedures;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramDatapointTests
    {
        [Fact]
        public void Value_Given15_ReturnsNoHearingLoss()
        {
            var result = new AudiogramDatapoint(15).Classification;
            
            Assert.Equal(HearingLoss.None, result);
        }
        [Fact]
        public void Value_Given30_ReturnsMildHearingLoss()
        {
            var result = new AudiogramDatapoint(30).Classification;
            
            Assert.Equal(HearingLoss.Mild, result);
        }
        [Fact]
        public void Value_Given55_ReturnsModerateHearingLoss()
        {
            var result = new AudiogramDatapoint(55).Classification;
            
            Assert.Equal(HearingLoss.Moderate, result);
        }
        [Fact]
        public void Value_Given75_ReturnsSevereHearingLoss()
        {
            var result = new AudiogramDatapoint(75).Classification;
            
            Assert.Equal(HearingLoss.Severe, result);
        }
        [Fact]
        public void Value_Given95_ReturnsProfoundHearingLoss()
        {
            var result = new AudiogramDatapoint(95).Classification;
            
            Assert.Equal(HearingLoss.Profound, result);
        }
    }
}
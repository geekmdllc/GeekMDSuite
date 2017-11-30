using GeekMDSuite.Procedures;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramDatasetTests
    {
        [Fact]
        public void Classify_GivenMax75dBLossAt3000Hz_ReturnsSevereHearingLoss()
        {
            var audiogramSet = new AudiogramDatasetBuilder()
                .Set125HertzDataPoint(30)
                .Set250HertzDataPoint(30)
                .Set500HertzDataPoint(30)
                .Set1000HertzDataPoint(30)
                .Set2000HertzDataPoint(30)
                .Set3000HertzDataPoint(75)
                .Set4000HertzDataPoint(30)
                .Set6000HertzDataPoint(30)
                .Set8000HertzDataPoint(30)
                .Build();
            
            var result = audiogramSet.Classification;
            
            Assert.Equal(HearingLoss.Severe, result);
        }
        
        [Fact]
        public void Classify_GivenMax15dBAt1000Hz_ReturnsNoHearingLoss()
        {
            var audiogramSet = new AudiogramDatasetBuilder()
                .Set125HertzDataPoint(10)
                .Set250HertzDataPoint(10)
                .Set500HertzDataPoint(10)
                .Set1000HertzDataPoint(15)
                .Set2000HertzDataPoint(10)
                .Set1000HertzDataPoint(10)
                .Set4000HertzDataPoint(10)
                .Set6000HertzDataPoint(10)
                .Set8000HertzDataPoint(10)
                .Build();
            
            var result = audiogramSet.Classification;
            
            Assert.Equal(HearingLoss.None, result);
        }
    }
}
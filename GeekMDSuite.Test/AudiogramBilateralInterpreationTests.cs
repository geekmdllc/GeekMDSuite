using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramBilateralInterpreationTests
    {
        [Fact]
        public void Interpret_GivenLeftSideWorseAt55db_ReturnsLeftSidedModerateHearingLoss()
        {
            var leftSet = new AudiogramDatasetBuilder()
                .Set500HertzDataPoint(55)
                .Build();
            var rightSet = new AudiogramDatasetBuilder()
                .Set1000HertzDataPoint(35)
                .Build();
            var result = new AudiogramInterpretation(new Audiogram(leftSet, rightSet)).Classification;
            
            Assert.Equal(Laterality.Left, result.Laterality);
            Assert.Equal(HearingLoss.Moderate, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenRightSideWorseAt95db_ReturnsRightSidedProfoundHearingLoss()
        {
            var leftSet = new AudiogramDatasetBuilder()
                .Set500HertzDataPoint(55)
                .Build();
            var rightSet = new AudiogramDatasetBuilder()
                .Set1000HertzDataPoint(95)
                .Build();
            var result = new AudiogramInterpretation(new Audiogram(leftSet, rightSet)).Classification;
            
            Assert.Equal(Laterality.Right, result.Laterality);
            Assert.Equal(HearingLoss.Profound, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenLeftAndRightWithin10dBOf70dB_ReturnsBilateralSevereHearingLoss()
        {
            var leftSet = new AudiogramDatasetBuilder()
                .Set500HertzDataPoint(66)
                .Build();
            var rightSet = new AudiogramDatasetBuilder()
                .Set1000HertzDataPoint(74)
                .Build();
            var result = new AudiogramInterpretation(new Audiogram(leftSet, rightSet)).Classification;
            
            Assert.Equal(Laterality.Bilateral, result.Laterality);
            Assert.Equal(HearingLoss.Severe, result.Classification);
        }
    }
}
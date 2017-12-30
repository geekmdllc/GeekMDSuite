using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class AudiogramDatasetInterpretationTests
    {
        [Theory]
        [InlineData(15, HearingLoss.None)]
        [InlineData(30, HearingLoss.Mild)]
        [InlineData(55, HearingLoss.Moderate)]
        [InlineData(75, HearingLoss.Severe)]
        [InlineData(95, HearingLoss.Profound)]
        public void Classify_GivenAValueAboveNormal_ReturnsCorrectClassification(int testValue,
            HearingLoss expectedClassification)
        {
            var rand = new Random();

            var audiogramSet = AudiogramDatasetBuilder
                                .Initialize()
                                .Set125HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set250HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set500HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set1000HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set2000HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set3000HertzDataPoint(testValue) // Always have at least one trigger
                                .Set4000HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set6000HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Set8000HertzDataPoint(SetValueInEitherNormalRangeOrToTestValue(rand, testValue))
                                .Build();
            
            var result = audiogramSet;
            var interp = new AudiogramDatasetClassification(result);
            
            Assert.Equal(expectedClassification, interp.Classification);
        }
    
        [Fact]
        public void NullDataset_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AudiogramDatasetClassification(null));
        }

        private static int SetValueInEitherNormalRangeOrToTestValue(Random rand, int value)
        {
            var randomVal = rand.Next(0, 19);
            return randomVal <= 10 ? randomVal : value;
        }
    }
}
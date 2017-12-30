using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramInterpretationTests
    {
        [Theory]
        [InlineData(10,10,Laterality.Bilateral, HearingLoss.None)]
        [InlineData(10,25,Laterality.Right, HearingLoss.Mild)]
        [InlineData(25,10,Laterality.Left, HearingLoss.Mild)]
        [InlineData(10,45,Laterality.Right, HearingLoss.Moderate)]
        [InlineData(45,10,Laterality.Left, HearingLoss.Moderate)]
        [InlineData(10,75,Laterality.Right, HearingLoss.Severe)]
        [InlineData(75,10,Laterality.Left, HearingLoss.Severe)]
        [InlineData(10,95,Laterality.Right, HearingLoss.Profound)]
        [InlineData(95,10,Laterality.Left, HearingLoss.Profound)]
        [InlineData(95,95,Laterality.Bilateral, HearingLoss.Profound)]
        public void Classification_GivenOneWorseSide_ReturnsCorrectLateralityAndClassification(int leftVal,
            int rightVal, Laterality expectedLaterality, HearingLoss expectedHearingLoss)
        {
            var leftSet = new AudiogramDatasetBuilder()
                .Set500HertzDataPoint(leftVal)
                .Build();
            var rightSet = new AudiogramDatasetBuilder()
                .Set1000HertzDataPoint(rightVal)
                .Build();
            var result = new AudiogramClassification(Audiogram.Build(leftSet, rightSet)).Classification;
            
            Assert.Equal(expectedLaterality, result.Laterality);
            Assert.Equal(expectedHearingLoss, result.Classification);
        }

        [Fact]
        public void NullDataSets_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new AudiogramClassification(null));
        }
    }
}
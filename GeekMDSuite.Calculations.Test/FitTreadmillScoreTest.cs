using System;
using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class FitTreadmillScoreTest
    {
        private Gender female = Gender.Female;
        private Gender male = Gender.Male;
        private double age = 63;
        private double metabolicEquivalents = 8;
        private double percentMaxHeartRateReached = 105.3;
        private double maleScoreOffset = -43;
        private double testFitScore = 39;
        
        [Fact]
        public void FitScoreReturnsCorrectFemaleValue()
        {
            var fitScore = FitTreadmillScore.CalculateScore(female, metabolicEquivalents, age,
                percentMaxHeartRateReached);

            Assert.InRange(fitScore, -8, -7);
        }
        [Fact]
        public void FitScoreReturnsCorrecMaleValue()
        {
            var fitScore = FitTreadmillScore.CalculateScore(male, metabolicEquivalents, age,
                percentMaxHeartRateReached);

            Assert.InRange(fitScore, -8 + maleScoreOffset, -7 + maleScoreOffset);
        }

        [Fact]
        public void ReturnsCorrectTenYearMortality()
        {
            var tenYearMortality = FitTreadmillScore.TenYearMortality(testFitScore);
            Assert.Equal(3, tenYearMortality);
        }
    }
}
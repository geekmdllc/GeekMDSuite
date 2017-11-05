using GeekMDSuite.Common;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class FitTreadmillScoreTest
    {
        private readonly Genders _female = Genders.Female;
        private readonly Genders _male = Genders.Male;
        private readonly double _age = 63;
        private readonly double _metabolicEquivalents = 8;
        private readonly double _percentMaxHeartRateReached = 105.3;
        private readonly double _maleScoreOffset = -43;
        private readonly double _testFitScore = 39;
        
        [Fact]
        public void FitScoreReturnsCorrectFemaleValue()
        {
            var fitScore = FitTreadmillScore.CalculateScore(new FitTreadmillScoreParameters(_female, _age, _percentMaxHeartRateReached, _metabolicEquivalents));

            Assert.InRange(fitScore, -8, -7);
        }
        [Fact]
        public void FitScoreReturnsCorrecMaleValue()
        {
            var fitScore = FitTreadmillScore.CalculateScore(new FitTreadmillScoreParameters(_male, _age, _percentMaxHeartRateReached, _metabolicEquivalents));

            Assert.InRange(fitScore, -8 + _maleScoreOffset, -7 + _maleScoreOffset);
        }

        [Fact]
        public void ReturnsCorrectTenYearMortality()
        {
            var tenYearMortality = FitTreadmillScore.TenYearMortality(_testFitScore);
            Assert.Equal(3, tenYearMortality);
        }
    }
}
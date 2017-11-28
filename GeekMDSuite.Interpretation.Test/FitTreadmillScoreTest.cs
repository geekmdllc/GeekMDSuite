using GeekMDSuite.Common;
using GeekMDSuite.Interpretation.Fitness;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class FitTreadmillScoreTest
    {
        private readonly GenderIdentity _female = GenderIdentity.Female;
        private readonly GenderIdentity _male = GenderIdentity.Male;
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
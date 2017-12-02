using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class FitTreadmillScoreTest
    {
        private readonly GenderIdentity _female = GenderIdentity.Female;
        private readonly GenderIdentity _male = GenderIdentity.Male;
        private const double Age = 63;
        private const double MetabolicEquivalents = 8;
        private const double PercentMaxHeartRateReached = 105.3;
        private const double MaleScoreOffset = -43;
        private const int TestFitScore = 39;

        [Fact]
        public void FitScoreReturnsCorrectFemaleValue()
        {
            var fitParams = new FitTreadmillScoreParameters(_female, Age, PercentMaxHeartRateReached, MetabolicEquivalents);
            var fitScore = new FitTreadmillScoreInterpretation(fitParams).Value;

            Assert.InRange(fitScore, -8, -7);
        }
        [Fact]
        public void FitScoreReturnsCorrecMaleValue()
        {
            var fitParams = new FitTreadmillScoreParameters(_male, Age, PercentMaxHeartRateReached, MetabolicEquivalents);
            var fitScore = new FitTreadmillScoreInterpretation(fitParams).Value;

            Assert.InRange(fitScore, -8 + MaleScoreOffset, -7 + MaleScoreOffset);
        }

        [Fact]
        public void ReturnsCorrectTenYearMortality()
        {
            var fitParams = new  FitTreadmillScoreParameters(GenderIdentity.Male, 55, 155, 10.5);
            var fitScore = new FitTreadmillScoreInterpretation(fitParams);
            Assert.Equal(3, fitScore.TenYearMortality);
        }
    }
}
using Xunit;

namespace GeekMDSuite.Test
{
    public class MetabolicEquivalentsTest
    {
        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private readonly GenderIdentity _male = GenderIdentity.Male;
        private readonly GenderIdentity _female = GenderIdentity.Female;
        private TreadmillProtocol protocol = TreadmillProtocol.Bruce;
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.Calculate(protocol, _male, _timeDuration);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.Calculate(protocol, _female, _timeDuration);
            Assert.InRange(result, 13, 14);
        }
    }
}
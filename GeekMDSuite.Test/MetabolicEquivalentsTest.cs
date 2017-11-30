using GeekMDSuite.Tools.MeasurementUnits;
using Xunit;

namespace GeekMDSuite.Test
{
    public class MetabolicEquivalentsTest
    {
        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private readonly Gender _male = new Gender(GenderIdentity.Male);
        private readonly Gender _female = new Gender(GenderIdentity.Female);
        private TreadmillProtocol protocol = TreadmillProtocol.Bruce;
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.FromTreadmillStressTest(protocol, _timeDuration, _male);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.FromTreadmillStressTest(protocol, _timeDuration, _female);
            Assert.InRange(result, 13, 14);
        }
    }
}
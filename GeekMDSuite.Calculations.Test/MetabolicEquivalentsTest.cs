using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class MetabolicEquivalentsTest
    {
        private int minutes = 11;
        private int seconds = 33;
        private Gender male = Gender.Male;
        private Gender female = Gender.Female;
        private TreadmillExerciseStressTestProtocol protocol = TreadmillExerciseStressTestProtocol.Bruce;
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.CalculateFromTreadmillExerciseStressTest(protocol, male, minutes, seconds);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.CalculateFromTreadmillExerciseStressTest(protocol, female, minutes, seconds);
            Assert.InRange(result, 13, 14);
        }
    }
}
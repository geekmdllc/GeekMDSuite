using GeekMDSuite.Calculations.MetabolicEquivalents;
using GeekMDSuite.Contracts;
using GeekMDSuite.Contracts.Procedures;
using Xunit;

namespace GeekMDSuite.Calculations.Test.MetabolicEquivalentsTest
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
            var result = FromTreadmillExerciseStressTest.Calculate(protocol, male, minutes, seconds);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = FromTreadmillExerciseStressTest.Calculate(protocol, female, minutes, seconds);
            Assert.InRange(result, 13, 14);
        }
    }
}
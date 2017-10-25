﻿using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class MetabolicEquivalentsTest
    {
        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private readonly Gender _male = Gender.Male;
        private readonly Gender _female = Gender.Female;
        private TreadmillExerciseStressTestProtocol protocol = TreadmillExerciseStressTestProtocol.Bruce;
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.CalculateFromTreadmillExerciseStressTest(protocol, _male, _timeDuration);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var result = MetabolicEquivalents.CalculateFromTreadmillExerciseStressTest(protocol, _female, _timeDuration);
            Assert.InRange(result, 13, 14);
        }
    }
}
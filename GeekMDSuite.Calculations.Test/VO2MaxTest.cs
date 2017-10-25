using System;
using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class Vo2MaxTest
    {

        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private const Gender _male = Gender.Male;
        private readonly Gender _female = Gender.Female;
        private readonly TreadmillExerciseStressTestProtocol _protocol = TreadmillExerciseStressTestProtocol.Bruce;
        private readonly TreadmillExerciseStressTestProtocol _unsupportedProtocol =
            TreadmillExerciseStressTestProtocol.Balke3Point0;
        
        [Fact]
        public void MaleResultInRange()
        {            
            var result = Vo2Max.CalculateFromTreadmillExerciseStressTest(_male, _protocol, _timeDuration);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {            
            var result = Vo2Max.CalculateFromTreadmillExerciseStressTest(_female, _protocol, _timeDuration);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                Vo2Max.CalculateFromTreadmillExerciseStressTest(_male, _unsupportedProtocol, _timeDuration));
        }
    }
}
using System;
using GeekMDSuite.Calculations.VO2Max;
using GeekMDSuite.Contracts;
using GeekMDSuite.Contracts.Procedures;
using Xunit;

namespace GeekMDSuite.Calculations.Test.VO2MaxTest
{
    public class CalculateTest
    {
        private int minutes = 11;
        private int seconds = 33;
        private Gender male = Gender.Male;
        private Gender female = Gender.Female;
        private TreadmillExerciseStressTestProtocol protocol = TreadmillExerciseStressTestProtocol.Bruce;
        private TreadmillExerciseStressTestProtocol unsupportedProtocol =
            TreadmillExerciseStressTestProtocol.Balke3Point0;
        
        [Fact]
        public void MaleResultInRange()
        {            
            var result = FromTreadmillExerciseStressTest.Calculate(protocol, male, minutes, seconds);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {            
            var result = FromTreadmillExerciseStressTest.Calculate(protocol, female, minutes, seconds);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                FromTreadmillExerciseStressTest.Calculate(unsupportedProtocol, female, minutes, seconds));
        }
    }
}
﻿using System;
using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Calculations.Test
{
    public class VO2MaxTest
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
            var result = Vo2Max.CalculateFromTreadmillExerciseStressTest(protocol, male, minutes, seconds);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {            
            var result = Vo2Max.CalculateFromTreadmillExerciseStressTest(protocol, female, minutes, seconds);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                Vo2Max.CalculateFromTreadmillExerciseStressTest(unsupportedProtocol, female, minutes, seconds));
        }
    }
}
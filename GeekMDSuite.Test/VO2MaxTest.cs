﻿using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class Vo2MaxTest
    {

        [Fact]
        public void MaleResultInRange()
        {            
            _patient.Gender = Gender.Build(GenderIdentity.Male);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _patient);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {          
            _patient.Gender = Gender.Build(GenderIdentity.Female);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _patient);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                CalculateVo2Max.FromTreadmillStressTest(_unsupportedProtocol, _timeDuration, _patient));
        }
        
        public Vo2MaxTest()
        {
            _timeDuration = new TimeDuration(11,33);
            _protocol = TreadmillProtocol.Bruce;
            _unsupportedProtocol = TreadmillProtocol.Balke3Point0;
            _patient = new Patient()
            {
                Gender = Gender.Build(GenderIdentity.Male),
                DateOfBirth = DateTime.Now.AddYears(-45)
            };
        }
        
        private readonly TimeDuration _timeDuration;
        private readonly TreadmillProtocol _protocol;
        private readonly TreadmillProtocol _unsupportedProtocol;
        private readonly Patient _patient;

    }
}
using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class Vo2MaxTest
    {
        public Vo2MaxTest()
        {
            _timeDuration = new TimeDuration(11,33);
            _protocol = TreadmillProtocol.Bruce;
            _unsupportedProtocol = TreadmillProtocol.Balke3Point0;
        }
        
        [Fact]
        public void MaleResultInRange()
        {            
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, patient.Object);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {          
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, patient.Object);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);
            
            Assert.Throws<NotImplementedException>(() =>
                CalculateVo2Max.FromTreadmillStressTest(_unsupportedProtocol, _timeDuration, patient.Object));
        }

        private readonly TimeDuration _timeDuration;
        private readonly TreadmillProtocol _protocol;
        private readonly TreadmillProtocol _unsupportedProtocol;

    }
}
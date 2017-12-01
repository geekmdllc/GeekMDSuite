using System;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class Vo2MaxTest
    {

        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private readonly TreadmillProtocol _protocol = TreadmillProtocol.Bruce;
        private readonly TreadmillProtocol _unsupportedProtocol =
            TreadmillProtocol.Balke3Point0;
        
        [Fact]
        public void MaleResultInRange()
        {            
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, patient.Object);
            Assert.InRange(result.Value, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {          
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, patient.Object);
            Assert.InRange(result.Value, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            
            Assert.Throws<NotImplementedException>(() =>
                CalculateVo2Max.FromTreadmillStressTest(_unsupportedProtocol, _timeDuration, patient.Object));
        }
    }
}
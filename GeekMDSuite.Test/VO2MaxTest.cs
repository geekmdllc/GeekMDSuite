using System;
using GeekMDSuite.Procedures;
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
        private const TreadmillProtocol Protocol = TreadmillProtocol.Bruce;
        private const TreadmillProtocol UnsupportedProtocol = TreadmillProtocol.Balke3Point0;
        //TODO: Confirm 'classification' is correct.
        [Fact]
        public void MaleResultInRange()
        {            
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(Protocol, _timeDuration, patient.Object);
            Assert.InRange(result.Value, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {          
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = CalculateVo2Max.FromTreadmillStressTest(Protocol, _timeDuration, patient.Object);
            Assert.InRange(result.Value, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);
            
            Assert.Throws<NotImplementedException>(() =>
                CalculateVo2Max.FromTreadmillStressTest(UnsupportedProtocol, _timeDuration, patient.Object));
        }
    }
}
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class MetabolicEquivalentsTest
    {
        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private TreadmillProtocol protocol = TreadmillProtocol.Bruce;
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = MetabolicEquivalents.FromTreadmillStressTest(protocol, _timeDuration, patient.Object);
            Assert.InRange(result, 11, 12);
        }
        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = MetabolicEquivalents.FromTreadmillStressTest(protocol, _timeDuration, patient.Object);
            Assert.InRange(result, 13, 14);
        }
    }
}
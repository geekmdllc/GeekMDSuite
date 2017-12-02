using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class MetabolicEquivalentsTest
    {
        private readonly Mock<ITreadmillExerciseStressTest> _mockTreadmill = BuildMockTreadmill();
        
        // Implicitly tests static method FromVo2Max(args..)
        [Fact]
        public void MaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            patient.Setup(p => p.Age).Returns(45);

            var result = CalculateMetabolicEquivalents.FromTreadmillStressTest(_mockTreadmill.Object, patient.Object);
            Assert.InRange(result, 11, 12);
        }

        [Fact]
        public void FemaleResultInRangeFromTreadmillExerciseStressTest()
        {
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            patient.Setup(p => p.Age).Returns(45);
            
            var result = CalculateMetabolicEquivalents.FromTreadmillStressTest(_mockTreadmill.Object, patient.Object);
            Assert.InRange(result, 13, 14);
        }
        
        private static Mock<ITreadmillExerciseStressTest> BuildMockTreadmill()
        {
            var mockTreadmill = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmill.Setup(t => t.Protocol).Returns(TreadmillProtocol.Bruce);
            mockTreadmill.Setup(t => t.Time.FractionalMinutes).Returns(11.0 + 33.0 / 60.0);
            return mockTreadmill;
        }
    }
}
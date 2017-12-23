using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.Generic;
using static GeekMDSuite.Tools.Fitness.CalculateMetabolicEquivalents;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class MetabolicEquivalentsTest
    {
        [Theory]
        [InlineData(45, GenderIdentity.Male, 11, 12)]
        [InlineData(45, GenderIdentity.Female, 13, 14)]
        public void GivenPatientAndTreamill_ReturnsCorrectResult(int age, GenderIdentity genderIdentity, int expectedLower, int expectedUpper)
        {
            var mockTreadmill = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmill.Setup(t => t.Protocol).Returns(TreadmillProtocol.Bruce);
            mockTreadmill.Setup(t => t.Time.FractionalMinutes).Returns(11.0 + 33.0 / 60.0);   
            
            var patient = new Mock<IPatient>();
            patient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            patient.Setup(p => p.Age).Returns(age);

            var result = FromTreadmillStressTest(mockTreadmill.Object, patient.Object);
            Assert.InRange(result, expectedLower, expectedUpper);
        }
  
        [Fact]
        public void NullTreadmillStressTest_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => FromTreadmillStressTest(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() =>
                FromTreadmillStressTest(new Mock<ITreadmillExerciseStressTest>().Object, null));
        }
    }
}
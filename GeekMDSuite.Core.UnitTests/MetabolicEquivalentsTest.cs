using System;
using GeekMDSuite.Core.Procedures;
using static GeekMDSuite.Core.Tools.Fitness.CalculateMetabolicEquivalents;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
{
    public class MetabolicEquivalentsTest
    {
        [Theory]
        [InlineData(45, GenderIdentity.Male, 11, 12)]
        [InlineData(45, GenderIdentity.Female, 13, 14)]
        public void GivenPatientAndTreamill_ReturnsCorrectResult(int age, GenderIdentity genderIdentity, int expectedLower, int expectedUpper)
        {
            var dateOfBirth = DateTime.Now.AddYears(-age);
            var patient = PatientBuilder.Initialize()
                .SetGender(genderIdentity)
                .SetDateOfBirth(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                .BuildWithoutModelValidation();

            var treadmill = TreadmillExerciseStressTestBuilder.Initialize()
                .SetTime(11, 33)
                .BuildWithoutModelValidation();

            var result = FromTreadmillStressTest(treadmill, patient);
            Assert.InRange(result, expectedLower, expectedUpper);
        }
  
        [Fact]
        public void NullTreadmillStressTest_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => FromTreadmillStressTest(null, PatientBuilder.Initialize().BuildWithoutModelValidation()));
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() =>
                FromTreadmillStressTest(TreadmillExerciseStressTestBuilder.Initialize().BuildWithoutModelValidation(), null));
        }
    }
}
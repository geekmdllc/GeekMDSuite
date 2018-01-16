using System;
using GeekMDSuite.Analytics.Tools.Fitness;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Tools.Fitness
{
    public class MetabolicEquivalentsTest
    {
        [Theory]
        [InlineData(45, GenderIdentity.Male, 11, 12)]
        [InlineData(45, GenderIdentity.Female, 13, 14)]
        public void GivenPatientAndTreamill_ReturnsCorrectResult(int age, GenderIdentity genderIdentity,
            int expectedLower, int expectedUpper)
        {
            var dateOfBirth = DateTime.Now.AddYears(-age);
            var patient = PatientBuilder.Initialize()
                .SetGender(genderIdentity)
                .SetDateOfBirth(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                .BuildWithoutModelValidation();


            var treadmill = TreadmillExerciseStressTestBuilder.Initialize()
                .SetTime(11, 33)
                .BuildWithoutModelValidation();

            var result = CalculateMetabolicEquivalents.FromTreadmillStressTest(treadmill, patient);
            Assert.InRange(result, expectedLower, expectedUpper);
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() =>
                CalculateMetabolicEquivalents.FromTreadmillStressTest(
                    TreadmillExerciseStressTestBuilder.Initialize().BuildWithoutModelValidation(), null));
        }

        [Fact]
        public void NullTreadmillStressTest_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
                CalculateMetabolicEquivalents.FromTreadmillStressTest(null,
                    PatientBuilder.Initialize().BuildWithoutModelValidation()));
        }
    }
}
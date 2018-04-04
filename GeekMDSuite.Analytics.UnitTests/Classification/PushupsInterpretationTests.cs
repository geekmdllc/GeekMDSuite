using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class PushupsInterpretationTests
    {
        public PushupsInterpretationTests()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
        }

        [Theory]
        [InlineData(0, GenderIdentity.Male, 40, FitnessClassification.VeryPoor)]
        [InlineData(5, GenderIdentity.Male, 40, FitnessClassification.Poor)]
        [InlineData(10, GenderIdentity.Male, 40, FitnessClassification.BelowAverage)]
        [InlineData(20, GenderIdentity.Male, 40, FitnessClassification.Average)]
        [InlineData(27, GenderIdentity.Male, 40, FitnessClassification.AboveAverage)]
        [InlineData(33, GenderIdentity.Male, 40, FitnessClassification.Good)]
        [InlineData(35, GenderIdentity.Male, 40, FitnessClassification.Excellent)]
        [InlineData(0, GenderIdentity.Female, 40, FitnessClassification.VeryPoor)]
        [InlineData(3, GenderIdentity.Female, 40, FitnessClassification.Poor)]
        [InlineData(7, GenderIdentity.Female, 40, FitnessClassification.BelowAverage)]
        [InlineData(17, GenderIdentity.Female, 40, FitnessClassification.Average)]
        [InlineData(24, GenderIdentity.Female, 40, FitnessClassification.AboveAverage)]
        [InlineData(30, GenderIdentity.Female, 40, FitnessClassification.Good)]
        [InlineData(33, GenderIdentity.Female, 40, FitnessClassification.Excellent)]
        public void Classification_GivenPushupCountAndPatient_ReturnsCorrectClassification(int count,
            GenderIdentity genderIdentity, int age, FitnessClassification expectedClassification)
        {
            var pushups = Pushups.Build(count);
            _patient.Gender = Gender.Build(genderIdentity);
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);

            var classification =
                new PushupsClassification(new PushupsClassificationParameters(pushups, _patient))
                    .Classification;

            Assert.Equal(expectedClassification, classification);
        }

        private readonly Patient _patient;

        [Fact]
        public void GivenNullPatient_ThrowsArguemntNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PushupsClassification(new PushupsClassificationParameters(Pushups.Build(0), null)));
        }

        [Fact]
        public void GivenNullPushups_ThrowsArgumentNullError()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PushupsClassification(new PushupsClassificationParameters(null,
                    PatientBuilder.Initialize().BuildWithoutModelValidation())));
        }
    }
}
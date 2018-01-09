using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class FitTreadmillScoreClassificationTest
    {
        public FitTreadmillScoreClassificationTest()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
        }

        // PercentMaxHeartRate +  12 * MetabolicEquivalents - 4 *  Age + (female ? 43 : 0)
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, 62.9298271155596)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, -1.32731574158328)]
        public void Value_GivenTreadmillAndPatientData_ReturnsCorrectValue(GenderIdentity gender, int age,
            int maxHeartRate, double minutes, double seconds, double expectedScore)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var tmst = TreadmillExerciseStressTestBuilder.Initialize()
                .SetMaximumHeartRate(maxHeartRate)
                .SetTime(minutes, seconds)
                .BuildWithoutModelValidation();

            var fitScore = new FitTreadmillScoreClassification(new TreadmillExerciseStressTestsClassificationParameters(tmst, _patient)).Value;

            Assert.InRange(fitScore, expectedScore - 0.001, expectedScore + 0.001);
        }

        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, 3)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, 11)]
        public void TenYearMortality_GivenTreadmillAndPatientData_ReturnsCorrectTenYearMortality(GenderIdentity gender,
            int age,
            int maxHeartRate, double minutes, double seconds, int expectedTenYearMortality)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var tmst = TreadmillExerciseStressTestBuilder.Initialize()
                .SetMaximumHeartRate(maxHeartRate)
                .SetTime(minutes, seconds)
                .BuildWithoutModelValidation();

            var tenYearMortality = new FitTreadmillScoreClassification(new TreadmillExerciseStressTestsClassificationParameters(tmst, _patient)).TenYearMortality;

            Assert.Equal(expectedTenYearMortality, tenYearMortality);
        }

        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, FitTreadmillScoreMortality.LowRisk)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, FitTreadmillScoreMortality.ModerateRisk)]
        public void Classification_GivenTreadmillAndPatientData_ReturnsCorrectClassification(GenderIdentity gender,
            int age,
            int maxHeartRate, double minutes, double seconds, FitTreadmillScoreMortality expectedClassification)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var tmst = TreadmillExerciseStressTestBuilder.Initialize()
                .SetMaximumHeartRate(maxHeartRate)
                .SetTime(minutes, seconds)
                .BuildWithoutModelValidation();

            var classification = new FitTreadmillScoreClassification(new TreadmillExerciseStressTestsClassificationParameters(tmst, _patient)).Classification;

            Assert.Equal(expectedClassification, classification);
        }

        private readonly Patient _patient;

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new FitTreadmillScoreClassification(new TreadmillExerciseStressTestsClassificationParameters(TreadmillExerciseStressTestBuilder.Initialize().BuildWithoutModelValidation(), null)));
        }

        [Fact]
        public void NullTreadmillStressTest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new FitTreadmillScoreClassification(new TreadmillExerciseStressTestsClassificationParameters(null, PatientBuilder.Initialize().BuildWithoutModelValidation())));
        }
    }
}
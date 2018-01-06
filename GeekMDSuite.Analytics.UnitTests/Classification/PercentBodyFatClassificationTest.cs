using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class PercentBodyFatClassificationTest
    {
        public PercentBodyFatClassificationTest()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
        }

        [Theory]
        [InlineData(PercentBodyFatClassification.LowerLimits.Male.Athletic - 1, GenderIdentity.Male,
            PercentBodyFat.UnderFat)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Male.Athletic, GenderIdentity.Male,
            PercentBodyFat.Athletic)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Male.Fit, GenderIdentity.Male, PercentBodyFat.Fitness)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Male.Acceptable, GenderIdentity.Male,
            PercentBodyFat.Acceptable)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Male.OverFat, GenderIdentity.Male, PercentBodyFat.OverFat)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Female.Athletic - 1, GenderIdentity.Female,
            PercentBodyFat.UnderFat)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Female.Athletic, GenderIdentity.Female,
            PercentBodyFat.Athletic)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Female.Fit, GenderIdentity.Female, PercentBodyFat.Fitness)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Female.Acceptable, GenderIdentity.Female,
            PercentBodyFat.Acceptable)]
        [InlineData(PercentBodyFatClassification.LowerLimits.Female.OverFat, GenderIdentity.Female,
            PercentBodyFat.OverFat)]
        public void Classify_GivenBodyCompositionAndBodyFatPercent_ReturnsCorrectClassification(double percentBodyFat,
            GenderIdentity genderIdentity, PercentBodyFat expectedClassification)
        {
            _patient.Gender = Gender.Build(genderIdentity);

            var bce = BodyCompositionExpandedBuilder.Initialize()
                .SetBodyFatPercentage(percentBodyFat)
                .BuildWithoutModelValidation();

            var classification = new PercentBodyFatClassification(bce, _patient).Classification;

            Assert.Equal(expectedClassification, classification);
        }

        private readonly Patient _patient;

        [Fact]
        public void GivenNullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PercentBodyFatClassification(null, PatientBuilder.Initialize().BuildWithoutModelValidation()));
        }

        [Fact]
        public void GivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PercentBodyFatClassification(
                    BodyCompositionExpandedBuilder.Initialize().BuildWithoutModelValidation(), null));
        }
    }
}
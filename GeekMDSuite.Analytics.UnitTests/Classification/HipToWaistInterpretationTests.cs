using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class HipToWaistInterpretationTests
    {
        public HipToWaistInterpretationTests()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
        }

        [Theory]
        [InlineData(0.89, GenderIdentity.Male, HipToWaistRatio.Normal)]
        [InlineData(0.99, GenderIdentity.Male, HipToWaistRatio.Overweight)]
        [InlineData(1.00, GenderIdentity.Male, HipToWaistRatio.Obese)]
        [InlineData(0.79, GenderIdentity.Female, HipToWaistRatio.Normal)]
        [InlineData(0.84, GenderIdentity.Female, HipToWaistRatio.Overweight)]
        [InlineData(0.85, GenderIdentity.Female, HipToWaistRatio.Obese)]
        public void Classification_GivenHipToWaistRatioAndGender_ReturnsCorrectClassification(double ratio,
            GenderIdentity genderIdentity, HipToWaistRatio expectedClassifcation)
        {
            _patient.Gender = Gender.Build(genderIdentity);

            var bodyComposition = BodyCompositionBuilder.Initialize()
                .SetHips(1)
                .SetWaist(ratio)
                .BuildWithoutModelValidation();

            var classification = new HipToWaistClassification(new BodyCompositionClassificationParameters(bodyComposition, _patient)).Classification;
            Assert.Equal(expectedClassifcation, classification);
        }

        private readonly Patient _patient;

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new HipToWaistClassification(new BodyCompositionClassificationParameters(BodyCompositionBuilder.Initialize().BuildWithoutModelValidation(), null)));
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new HipToWaistClassification(new BodyCompositionClassificationParameters(null, PatientBuilder.Initialize().BuildWithoutModelValidation())));
        }
    }
}
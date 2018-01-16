using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.MeasurementUnits.Conversion;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class BodyMassIndexTest
    {
        [Theory] // Asians and Non-Asians are classfied differently.
        [InlineData(BodyMassIndexClassification.LowerLimits.UnderWeight - 1, Race.Asian,
            BodyMassIndex.SeverelyUnderweight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.UnderWeight, Race.Asian, BodyMassIndex.Underweight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.NormalWeight, Race.Asian, BodyMassIndex.NormalWeight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.Overweight.Asian, Race.Asian, BodyMassIndex.OverWeight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass1.Asian, Race.Asian, BodyMassIndex.ObesityClass1)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass2, Race.Asian, BodyMassIndex.ObesityClass2)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass3, Race.Asian, BodyMassIndex.ObesityClass3)]
        [InlineData(BodyMassIndexClassification.LowerLimits.UnderWeight - 1, Race.BlackOrAfricanAmerican,
            BodyMassIndex.SeverelyUnderweight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.UnderWeight, Race.White, BodyMassIndex.Underweight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.NormalWeight, Race.Latin, BodyMassIndex.NormalWeight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.Overweight.NonAsian, Race.White, BodyMassIndex.OverWeight)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass1.NonAsian, Race.BlackOrAfricanAmerican,
            BodyMassIndex.ObesityClass1)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass2, Race.NativeHawaiianOrOtherPacificIslander,
            BodyMassIndex.ObesityClass2)]
        [InlineData(BodyMassIndexClassification.LowerLimits.ObeseClass3, Race.BlackOrAfricanAmerican,
            BodyMassIndex.ObesityClass3)]
        public void Classification_GivenDemographicsAndBmiInfo_ReturnsCorrectBmiClassification(
            double bmi, Race race, BodyMassIndex expectecBodyMassIndex)
        {
            var bodyComposition = BodyCompositionBuilder.Initialize()
                .SetHeight(LengthConversion.CentimetersToInches(100))
                .SetWeight(MassConversion.KilogramsToLbs(bmi))
                .BuildWithoutModelValidation();

            var patient = PatientBuilder.Initialize()
                .SetRace(race)
                .BuildWithoutModelValidation();

            var result =
                new BodyMassIndexClassification(new BodyCompositionClassificationParameters(bodyComposition, patient))
                    .Classification;

            Assert.Equal(expectecBodyMassIndex, result);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new BodyMassIndexClassification(new BodyCompositionClassificationParameters(null,
                        PatientBuilder.Initialize().BuildWithoutModelValidation()))
                    .Classification);
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new BodyMassIndexClassification(
                    new BodyCompositionClassificationParameters(
                        BodyCompositionBuilder.Initialize().BuildWithoutModelValidation(), null)));
        }
    }
}
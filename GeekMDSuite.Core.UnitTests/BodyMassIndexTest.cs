using System;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;
using static GeekMDSuite.Core.Analytics.Classification.BodyMassIndexClassification;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
{
    public class BodyMassIndexTest
    {
        [Theory] // Asians and Non-Asians are classfied differently.
        [InlineData(LowerLimits.UnderWeight - 1, Race.Asian, BodyMassIndex.SeverelyUnderweight)]
        [InlineData(LowerLimits.UnderWeight, Race.Asian, BodyMassIndex.Underweight)]
        [InlineData(LowerLimits.NormalWeight, Race.Asian, BodyMassIndex.NormalWeight)]
        [InlineData(LowerLimits.Overweight.Asian, Race.Asian, BodyMassIndex.OverWeight)]
        [InlineData(LowerLimits.ObeseClass1.Asian, Race.Asian, BodyMassIndex.ObesityClass1)]
        [InlineData(LowerLimits.ObeseClass2, Race.Asian, BodyMassIndex.ObesityClass2)]
        [InlineData(LowerLimits.ObeseClass3, Race.Asian, BodyMassIndex.ObesityClass3)]
        [InlineData(LowerLimits.UnderWeight - 1, Race.BlackOrAfricanAmerican, BodyMassIndex.SeverelyUnderweight)]
        [InlineData(LowerLimits.UnderWeight, Race.White, BodyMassIndex.Underweight)]
        [InlineData(LowerLimits.NormalWeight, Race.Latin, BodyMassIndex.NormalWeight)]
        [InlineData(LowerLimits.Overweight.NonAsian, Race.White, BodyMassIndex.OverWeight)]
        [InlineData(LowerLimits.ObeseClass1.NonAsian, Race.BlackOrAfricanAmerican, BodyMassIndex.ObesityClass1)]
        [InlineData(LowerLimits.ObeseClass2, Race.NativeHawaiianOrOtherPacificIslander, BodyMassIndex.ObesityClass2)]
        [InlineData(LowerLimits.ObeseClass3, Race.BlackOrAfricanAmerican, BodyMassIndex.ObesityClass3)]
        
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
            
            var result = new BodyMassIndexClassification(bodyComposition, patient).Classification;
            
            Assert.Equal(expectecBodyMassIndex, result);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new BodyMassIndexClassification(null, PatientBuilder.Initialize().BuildWithoutModelValidation()).Classification);
        }
        
        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new BodyMassIndexClassification(BodyCompositionBuilder.Initialize().BuildWithoutModelValidation(), null));
        }
    }
}

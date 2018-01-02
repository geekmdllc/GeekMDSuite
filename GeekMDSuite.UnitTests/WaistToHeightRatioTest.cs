﻿using System;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Moq;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class WaistToHeightRatioTest
    {
        [Theory]
        [InlineData(0.33, GenderIdentity.Male, WaistToHeightRatio.ExtremelySlim)]
        [InlineData(0.42, GenderIdentity.Male, WaistToHeightRatio.Slim)]
        [InlineData(0.52, GenderIdentity.Male, WaistToHeightRatio.Healthy)]
        [InlineData(0.57, GenderIdentity.Male, WaistToHeightRatio.Overweight)]
        [InlineData(0.62, GenderIdentity.Male, WaistToHeightRatio.VeryOverweight)]
        [InlineData(0.65, GenderIdentity.Male, WaistToHeightRatio.MorbidlyObese)]
        [InlineData(0.33, GenderIdentity.Female, WaistToHeightRatio.ExtremelySlim)]
        [InlineData(0.41, GenderIdentity.Female, WaistToHeightRatio.Slim)]
        [InlineData(0.48, GenderIdentity.Female, WaistToHeightRatio.Healthy)]
        [InlineData(0.53, GenderIdentity.Female, WaistToHeightRatio.Overweight)]
        [InlineData(0.57, GenderIdentity.Female, WaistToHeightRatio.VeryOverweight)]
        [InlineData(0.60, GenderIdentity.Female, WaistToHeightRatio.MorbidlyObese)]
        public void Classification_GivenPatientAndData_ReturnsCorrectClassification(double ratio,
            GenderIdentity genderIdentity, WaistToHeightRatio expectedWaistToHeightRatio)
        {
            _patient.Gender = Gender.Build(genderIdentity);

            var bodyComposition = BodyCompositionBuilder.Initialize()
                .SetHeight(Tools.MeasurementUnits.Conversion.LengthConversion.CentimetersToInches(1))
                .SetWaist(Tools.MeasurementUnits.Conversion.LengthConversion.CentimetersToInches(ratio))
                .BuildWithoutModelValidation();
            
            var classification = new WaistToHeightRatioClassification(bodyComposition, _patient).Classification;
            
            Assert.Equal(expectedWaistToHeightRatio, classification);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WaistToHeightRatioClassification(null, PatientBuilder.Initialize().BuildWithoutModelValidation()));
        }
        
        [Fact]
        public void NullPatient_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
                new WaistToHeightRatioClassification(new Mock<IBodyComposition>().Object, null));
        }

        public WaistToHeightRatioTest()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
        }
        private readonly Patient _patient;
    }
}
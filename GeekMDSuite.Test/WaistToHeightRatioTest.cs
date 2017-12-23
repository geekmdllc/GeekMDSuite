using System;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
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
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(1);
            bc.Setup(b => b.Waist.Centimeters).Returns(ratio);
            
            var classification = new WaistToHeightRatioInterpretation(bc.Object, mockPatient.Object).Classification;
            
            Assert.Equal(expectedWaistToHeightRatio, classification);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WaistToHeightRatioInterpretation(null, new Mock<IPatient>().Object));
        }
        
        [Fact]
        public void NullPatient_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
                new WaistToHeightRatioInterpretation(new Mock<IBodyComposition>().Object, null));
        }
    }
}
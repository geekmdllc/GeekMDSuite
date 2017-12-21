using GeekMDSuite.Services.Interpretation;
using static GeekMDSuite.Services.Interpretation.BodyMassIndexInterpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
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
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(bc => bc.Height.Meters).Returns(1);
            mockBodyComposition.Setup(bc => bc.Weight.Kilograms).Returns(bmi);
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Race).Returns(race);
            
            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            
            Assert.Equal(expectecBodyMassIndex, result);
        }
    }
}

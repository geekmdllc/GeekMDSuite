using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;
using static GeekMDSuite.Services.Interpretation.PercentBodyFatInterpretation.LowerLimits;

namespace GeekMDSuite.Test
{
    public class PercentBodyFatTest
    {
        [Theory]
        [InlineData(Male.Athletic - 1, GenderIdentity.Male, PercentBodyFat.UnderFat)]
        [InlineData(Male.Athletic, GenderIdentity.Male, PercentBodyFat.Athletic)]
        [InlineData(Male.Fit, GenderIdentity.Male, PercentBodyFat.Fitness)]
        [InlineData(Male.Acceptable, GenderIdentity.Male, PercentBodyFat.Acceptable)]
        [InlineData(Male.OverFat, GenderIdentity.Male, PercentBodyFat.OverFat)]
        [InlineData(Female.Athletic - 1, GenderIdentity.Female, PercentBodyFat.UnderFat)]
        [InlineData(Female.Athletic, GenderIdentity.Female, PercentBodyFat.Athletic)]
        [InlineData(Female.Fit, GenderIdentity.Female, PercentBodyFat.Fitness)]
        [InlineData(Female.Acceptable, GenderIdentity.Female, PercentBodyFat.Acceptable)]
        [InlineData(Female.OverFat, GenderIdentity.Female, PercentBodyFat.OverFat)]
        public void Classify_GivenBodyCompositionAndBodyFatPercent_ReturnsCorrectClassification(double percentBodyFat, 
            GenderIdentity genderIdentity, PercentBodyFat expectedClassification)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(percentBodyFat);
            
            var classification = new PercentBodyFatInterpretation(bce.Object, mockPatient.Object).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }
    }
}
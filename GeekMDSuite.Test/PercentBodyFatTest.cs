using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PercentBodyFatTest
    {
        [Fact]
        public void Interpret_GivenMaleWith5Percent_ReturnsUnderFat()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(5);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Male);
            
            Assert.Equal(PercentBodyFatClassification.UnderFat, result.Classification);
        }
        [Fact]
        public void Interpret_GivenMaleWith13point9Percent_ReturnsAthletic()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(13.9);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Athletic, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith15Percent_ReturnsFitness()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(15);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Fitness, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith20Percent_ReturnsAcceptable()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(20);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Acceptable, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith30Percent_ReturnsOverFat()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(30);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.OverFat, result.Classification);
        }
        [Fact]
        public void Interpret_GivenFemaleWith13Percent_ReturnsUnderFat()
        {            
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(13);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.UnderFat, result.Classification);
        }
        [Fact]
        public void Interpret_GivenFemaleWith20point9Percent_ReturnsAthletic()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(20.9);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.Athletic, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith24point9Percent_ReturnsFitness()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(24.9);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.Fitness, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith30Percent_ReturnsAcceptable()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(30);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.Acceptable, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith35Percent_ReturnsOverFat()
        {
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(35);
            var result = new PercentBodyFatInterpretation(bce.Object, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.OverFat, result.Classification);
        }

    }
}
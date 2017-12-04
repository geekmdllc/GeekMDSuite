using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class WaistToHeightRatioTest
    {
        [Fact]
        public void Intepret_Male0point33_ReturnsExtremelySlim()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(33);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.ExtremelySlim, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point33_ReturnsExtremelySlim()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(33);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Female);
            
            Assert.Equal(WaistToHeightRatioClassification.ExtremelySlim, result.Classification);
        }
        
        [Fact]
        public void Intepret_Male0point42_ReturnsSlim()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(42);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.Slim, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point41_ReturnsSlim()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(41);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.Slim, result.Classification);
        }

        [Fact]
        public void Intepret_Male0point52_ReturnsHealthy()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(52);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.NonBinaryXy);
            
            Assert.Equal(WaistToHeightRatioClassification.Healthy, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point48_ReturnsHealthy()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(48);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.Healthy, result.Classification);
        }
        
        [Fact]
        public void Intepret_Male0point57_ReturnsOverweight()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(57);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.NonBinaryXy);
            
            Assert.Equal(WaistToHeightRatioClassification.Overweight, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point53_ReturnsOverweight()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(53);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Female);
            
            Assert.Equal(WaistToHeightRatioClassification.Overweight, result.Classification);
        }
        
        [Fact]
        public void Intepret_Male0point62_ReturnsVeryOverweight()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(62);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.VeryOverweight, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point57_ReturnsVeryOverweight()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(57);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Female);
            
            Assert.Equal(WaistToHeightRatioClassification.VeryOverweight, result.Classification);
        }
        
        [Fact]
        public void Intepret_Male0point65_ReturnsMorbidlyObese()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(65);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Male);
            
            Assert.Equal(WaistToHeightRatioClassification.MorbidlyObese, result.Classification);
        }

        [Fact]
        public void Interpret_Female0point60_ReturnsMorbidlyObese()
        {
            var bc = new Mock<IBodyComposition>();
            bc.Setup(b => b.Height.Centimeters).Returns(100);
            bc.Setup(b => b.Waist.Centimeters).Returns(60);
            
            var result = new WaistToHeightRatioInterpretation(bc.Object, GenderIdentity.Female);
            
            Assert.Equal(WaistToHeightRatioClassification.MorbidlyObese, result.Classification);
        }
    }
}
using GeekMDSuite;
using GeekMDSuite.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test.BodyCompositionTests
{
    public class WaistToHeightRatioTest
    {
        [Fact]
        public void Intepret_Male0point33_ReturnsExtremelySlim()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.33);
            Assert.Equal(WaistToHeightRatioClassification.ExtremelySlim, result);
        }

        [Fact]
        public void Interpret_Female0point33_ReturnsExtremelySlim()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.33);
            Assert.Equal(WaistToHeightRatioClassification.ExtremelySlim, result);
        }
        
        [Fact]
        public void Intepret_Male0point42_ReturnsSlim()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.42);
            Assert.Equal(WaistToHeightRatioClassification.Slim, result);
        }

        [Fact]
        public void Interpret_Female0point41_ReturnsSlim()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.41);
            Assert.Equal(WaistToHeightRatioClassification.Slim, result);
        }

        [Fact]
        public void Intepret_Male0point52_ReturnsHealthy()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.52);
            Assert.Equal(WaistToHeightRatioClassification.Healthy, result);
        }

        [Fact]
        public void Interpret_Female0point48_ReturnsHealthy()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.48);
            Assert.Equal(WaistToHeightRatioClassification.Healthy, result);
        }
        
        [Fact]
        public void Intepret_Male0point57_ReturnsOverweight()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.57);
            Assert.Equal(WaistToHeightRatioClassification.Overweight, result);
        }

        [Fact]
        public void Interpret_Female0point53_ReturnsOverweight()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.53);
            Assert.Equal(WaistToHeightRatioClassification.Overweight, result);
        }
        
        [Fact]
        public void Intepret_Male0point62_ReturnsVeryOverweight()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.62);
            Assert.Equal(WaistToHeightRatioClassification.VeryOverweight, result);
        }

        [Fact]
        public void Interpret_Female0point57_ReturnsVeryOverweight()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.57);
            Assert.Equal(WaistToHeightRatioClassification.VeryOverweight, result);
        }
        
        [Fact]
        public void Intepret_Male0point65_ReturnsMorbidlyObese()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.NonBinaryXy, 0.65);
            Assert.Equal(WaistToHeightRatioClassification.MorbidlyObese, result);
        }

        [Fact]
        public void Interpret_Female0point60_ReturnsMorbidlyObese()
        {
            var result = WaistToHeightRatio.Interpret(GenderIdentity.Female, 0.60);
            Assert.Equal(WaistToHeightRatioClassification.MorbidlyObese, result);
        }
    }
}
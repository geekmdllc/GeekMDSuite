using GeekMDSuite.Common;
using GeekMDSuite.Interpretation.BodyComposition;
using Xunit;

namespace GeekMDSuite.Interpretation.Test.BodyCompositionTests
{
    public class PercentBodyFatTest
    {
        [Fact]
        public void Interpret_GivenMaleWith5Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Male, 5);
            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenMaleWith13point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Male, 13.9);
            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith15Percent_ReturnsFitness()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Male, 15);
            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith20Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Male, 20);
            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith30Percent_ReturnsOverFat()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Male, 30);
            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith13Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Female, 13);
            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith20point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Female, 20.9);
            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith24point9Percent_ReturnsFitness()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Female, 24.9);
            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith30Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Female, 30);
            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith35Percent_ReturnsOverFat()
        {
            var result = PercentBodyFat.Interpret(GenderIdentity.Female, 35);
            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }
    }
}
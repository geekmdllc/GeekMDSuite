using GeekMDSuite.Common;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class PercentBodyFatTest
    {
        [Fact]
        public void Interpret_GivenMaleWith5Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFat.Interpret(Genders.Male, 5);
            Assert.Equal(BodyFatCategories.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenMaleWith13point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFat.Interpret(Genders.Male, 13.9);
            Assert.Equal(BodyFatCategories.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith15Percent_ReturnsFitness()
        {
            var result = PercentBodyFat.Interpret(Genders.Male, 15);
            Assert.Equal(BodyFatCategories.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith20Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFat.Interpret(Genders.Male, 20);
            Assert.Equal(BodyFatCategories.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith30Percent_ReturnsOverFat()
        {
            var result = PercentBodyFat.Interpret(Genders.Male, 30);
            Assert.Equal(BodyFatCategories.OverFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith13Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFat.Interpret(Genders.Female, 13);
            Assert.Equal(BodyFatCategories.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith20point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFat.Interpret(Genders.Female, 20.9);
            Assert.Equal(BodyFatCategories.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith24point9Percent_ReturnsFitness()
        {
            var result = PercentBodyFat.Interpret(Genders.Female, 24.9);
            Assert.Equal(BodyFatCategories.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith30Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFat.Interpret(Genders.Female, 30);
            Assert.Equal(BodyFatCategories.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith35Percent_ReturnsOverFat()
        {
            var result = PercentBodyFat.Interpret(Genders.Female, 35);
            Assert.Equal(BodyFatCategories.OverFat, result);
        }
    }
}
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class QuantitativeLabInterpretationTests
    {
        [Fact]
        public void Testosterone_Given970US_ReturnsHigh()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = Quantitative.Serum.TestosteroneTotal(970);
            
            var classification = new QuantitativeLabInterpretation(test, mockPatient.Object).Classification;
            
            Assert.Equal(LaboratoryResult.High, classification);
        }
        
        [Fact]
        public void Insulin_Given2point5US_ReturnsLow()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = Quantitative.Serum.Insulin(2.5);
            
            var classification = new QuantitativeLabInterpretation(test, mockPatient.Object).Classification;
            
            Assert.Equal(LaboratoryResult.Low, classification);
        }
        
        [Fact]
        public void Insulin_Given25US_ReturnsHigh()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = Quantitative.Serum.Insulin(25);
            
            var classification = new QuantitativeLabInterpretation(test, mockPatient.Object).Classification;
            
            Assert.Equal(LaboratoryResult.High, classification);
        }
    }
}
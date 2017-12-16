using GeekMDSuite.LaboratoryData;
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
            mockPatient.Setup(p => p.Age).Returns(37);
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = new TestosteroneTotalSerum(970, MeasurementSystem.TraditionalUS);
            
            var classification = new QuantitativeLabInterpretation(test, mockPatient.Object).Classification;
            
            Assert.Equal(LaboratoryResult.High, classification);
        }
    }
}
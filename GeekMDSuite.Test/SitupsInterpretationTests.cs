using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SitupsInterpretationTests
    {
        [Fact]
        public void Classification_Given24SitupsAnd40yrMale_ReturnsAverage()
        {
            var pushups = new Situps(24);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(p => p.Age).Returns(40);

            var classification = new SitupsInterpretation(pushups, mockPt.Object).Classification;

            Assert.Equal(FitnessClassification.Average, classification);
        }
        
        [Fact]
        public void Classification_Given24SitupsAnd40yrFemale_ReturnsBelowAverage()
        {
            var pushups = new Situps(24);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            mockPt.Setup(p => p.Age).Returns(40);

            var classification = new SitupsInterpretation(pushups, mockPt.Object).Classification;

            Assert.Equal(FitnessClassification.BelowAverage, classification);
        }
    }
}
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PushupsInterpretationTests
    {
        [Fact]
        public void Classification_Given24PushupsAnd40yrMale_ReturnsAverage()
        {
            var pushups = new Pushups(24);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(p => p.Age).Returns(40);

            var classification = new PushupsInterpretation(pushups, mockPt.Object).Classification;

            Assert.Equal(FitnessClassification.Average, classification);
        }
        
        [Fact]
        public void Classification_Given24PushupsAnd40yrFemale_ReturnsAboveAverage()
        {
            var pushups = new Pushups(24);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            mockPt.Setup(p => p.Age).Returns(40);

            var classification = new PushupsInterpretation(pushups, mockPt.Object).Classification;

            Assert.Equal(FitnessClassification.AboveAverage, classification);
        }
    }
}
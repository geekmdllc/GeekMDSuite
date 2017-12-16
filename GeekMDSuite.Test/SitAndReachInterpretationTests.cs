using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SitAndReachInterpretationTests
    {
        [Fact]
        public void Classification_Given32yrMaleWith8cmReach_ReturnsAboveAverage()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(32);
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            var sitAndReach = new SitAndReach(8);
            
            var classification = new SitAndReachInterpretation(sitAndReach, mockPatient.Object).Classification;
            
            Assert.Equal(FitnessClassification.AboveAverage, classification);
        }
        
        [Fact]
        public void Classification_Given32yrFemaleWith8cmReach_ReturnsAverage()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(32);
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            var sitAndReach = new SitAndReach(8);
            
            var classification = new SitAndReachInterpretation(sitAndReach, mockPatient.Object).Classification;
            
            Assert.Equal(FitnessClassification.Average, classification);
        }
    }
}
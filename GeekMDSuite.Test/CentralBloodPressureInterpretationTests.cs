using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CentralBloodPressureInterpretationTests
    {
        // Augmetntation pressure, pulse pressure, augmented index, pulse wave velocity, etc. 
        // all implement an identical system, so just checking CentralSystolic.
        [Fact]
        public void Classification_GivenNormalCentralSystolic_ReturnsNormal()
        {
            var cbp = new CentralBloodPressure(103, 28, 0, 0, 19, 8.1);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(19);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);

            Assert.Equal(CentralBloodPressureCategory.Normal, test.Classification.Category);
        }
        
        [Fact]
        public void Classification_GivenLowNormalCentralSystolic_ReturnsLowNormal()
        {
            var cbp = new CentralBloodPressure(90, 28, 0, 0, 19, 8.1);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(19);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);
            
            Assert.Equal(CentralBloodPressureCategory.LowNormal, test.Classification.Category);
        }
        [Fact]
        public void Classification_GivenLowCentralSystolic_ReturnsLow()
        {
            var cbp = new CentralBloodPressure(80, 28, 0, 0, 19, 8.1);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(19);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);
            
            Assert.Equal(CentralBloodPressureCategory.Low, test.Classification.Category);
        }
        [Fact]
        public void Classification_GivenHighNormalCentralSystolic_ReturnsHighNormal()
        {
            var cbp = new CentralBloodPressure(116, 28, 0, 0, 19, 8.1);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(19);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);
            
            Assert.Equal(CentralBloodPressureCategory.HighNormal, test.Classification.Category);
        }
        [Fact]
        public void Classification_GivenHighCentralSystolic_ReturnsHigh()
        {
            var cbp = new CentralBloodPressure(120, 28, 0, 0, 19, 8.1);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(19);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);
            
            Assert.Equal(CentralBloodPressureCategory.High, test.Classification.Category);
        }
    }
}
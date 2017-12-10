using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CentralBloodPressureInterpretationTests
    {
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
            Console.WriteLine($"Category: {test.Classification.Category} | Reference Age: {test.Classification.ReferenceAge}");
        }
    }
}
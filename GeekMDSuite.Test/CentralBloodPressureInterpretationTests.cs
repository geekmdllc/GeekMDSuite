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
        public void Test()
        {
            var cbp = new CentralBloodPressure(105, 25, 8, 11, 35, 15);
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(GenderIdentity.Male);
            mockPt.Setup(patient => patient.Age).Returns(45);

            var test = new CentralBloodPressureInterpretation(cbp, mockPt.Object);

            Console.WriteLine($"Category: {test.Classification.Category} | Reference Age: {test.Classification.ReferenceAge}");
        }
    }
}
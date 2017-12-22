using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CentralBloodPressureInterpretationTests
    {
        [Theory]
        [InlineData(103, 28, 0, 0, 19, 8.1, GenderIdentity.Male, 19, CentralBloodPressureCategory.Normal)]
        [InlineData(90, 28, 0, 0, 19, 8.1, GenderIdentity.Male, 19, CentralBloodPressureCategory.LowNormal)]
        [InlineData(80, 28, 0, 0, 19, 8.1, GenderIdentity.Male, 19, CentralBloodPressureCategory.Low)]
        [InlineData(116, 28, 0, 0, 19, 8.1, GenderIdentity.Male, 19, CentralBloodPressureCategory.HighNormal)]
        [InlineData(120, 28, 0, 0, 19, 8.1, GenderIdentity.Male, 19, CentralBloodPressureCategory.High)]
        //TODO: Cover PP, AP, AIx, RA, PWV
        public void Classification_GivenCentralSystolicValues_ReturnsCorrectCategory(int csp, int pp, int ap, 
            int aix, int ra, double pwv, GenderIdentity genderIdentity, int age, CentralBloodPressureCategory expectctedCategory)
        {
            var cbp = new CentralBloodPressureBuilder()
                .SetCentralSystolicPressure(csp)
                .SetPulsePressure(pp)
                .SetAugmentedPressure(ap)
                .SetAugmentedIndex(aix)
                .SetReferenceAge(ra)
                .SetPulseWaveVelocity(pwv)
                .Build();
            
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(patient => patient.Gender.Category).Returns(genderIdentity);
            mockPt.Setup(patient => patient.Age).Returns(age);

            var actualCategory = new CentralBloodPressureInterpretation(cbp, mockPt.Object).Classification.Category;

            Assert.Equal(expectctedCategory, actualCategory);
        }
    }
}
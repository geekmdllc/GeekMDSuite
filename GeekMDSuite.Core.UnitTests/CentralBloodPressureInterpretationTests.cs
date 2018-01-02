using System;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.Core.Procedures;
using Moq;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
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

            var patient = PatientBuilder.Initialize()
                .SetGender(GenderIdentity.Male)
                .SetDateOfBirth(DateTime.Now.AddYears(-age))
                .BuildWithoutModelValidation();


            var actualCategory = new CentralBloodPressureClassification(cbp, patient).Classification.Category;

            Assert.Equal(expectctedCategory, actualCategory);
        }
    }
}
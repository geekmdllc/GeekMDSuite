using System;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Moq;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class HipToWaistInterpretationTests
    {
        [Theory]
        [InlineData(0.89, GenderIdentity.Male, HipToWaistRatio.Normal)]
        [InlineData(0.99, GenderIdentity.Male, HipToWaistRatio.Overweight)]
        [InlineData(1.00, GenderIdentity.Male, HipToWaistRatio.Obese)]
        [InlineData(0.79, GenderIdentity.Female, HipToWaistRatio.Normal)]
        [InlineData(0.84, GenderIdentity.Female, HipToWaistRatio.Overweight)]
        [InlineData(0.85, GenderIdentity.Female, HipToWaistRatio.Obese)]
        public void Classification_GivenHipToWaistRatioAndGender_ReturnsCorrectClassification(double ratio, 
            GenderIdentity genderIdentity, HipToWaistRatio expectedClassifcation)
        {
            _patient.Gender = Gender.Build(genderIdentity);
            
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(1);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(ratio);

            var classification = new HipToWaistClassification(mockBodyComposition.Object, _patient).Classification;
            Assert.Equal(expectedClassifcation, classification);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HipToWaistClassification(new Mock<IBodyComposition>().Object, null));
        }
        
        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HipToWaistClassification(null, new Mock<IPatient>().Object));
        }

        public HipToWaistInterpretationTests()
        {
            _patient = new Patient();
        }

        private Patient _patient;
    }
    
    
}
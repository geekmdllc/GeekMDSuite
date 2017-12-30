using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Moq;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class QualitativeLabInterpretationTests
    {
        [Theory]
        [InlineData(QualitativeLabResult.Positive, QualitativeLabResult.Positive)]
        [InlineData(QualitativeLabResult.Negative, QualitativeLabResult.Negative)]
        public void QualitativeLab_GivenResult_ReturnsCorrectClassification(
            QualitativeLabResult result, QualitativeLabResult expectedClassification)
        {
            var patient = new Patient()
            {
                Gender = Gender.Build(GenderIdentity.Male)
            };

            var test = Qualitative.HepatitisCAntibody(result);

            var interp = new QualitativeLabClassification(test, patient);

            var classification = interp.Classification;

            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void GivenNullQualitytativeTest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new QualitativeLabClassification(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void GivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new QualitativeLabClassification(new Mock<IQualitativeLab>().Object, null));
        }
    }
}
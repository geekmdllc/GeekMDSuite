using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class QualitativeLabInterpretationTests
    {
        [Theory]
        [InlineData(QualitativeLabResult.Positive, QualitativeLabResult.Positive)]
        [InlineData(QualitativeLabResult.Negative, QualitativeLabResult.Negative)]
        public void QualitativeLab_GivenResult_ReturnsCorrectClassification(
            QualitativeLabResult result, QualitativeLabResult expectedClassification)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = Qualitative.HepatitisCAntibody(result);

            var interp = new QualitativeLabInterpretation(test, mockPatient.Object);

            var classification = interp.Classification;

            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void GivenNullQualitytativeTest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new QualitativeLabInterpretation(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void GivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new QualitativeLabInterpretation(new Mock<IQualitativeLab>().Object, null));
        }
    }
}
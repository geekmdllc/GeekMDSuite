using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class QualitativeLabInterpretationTests
    {
        [Theory]
        [InlineData(QualitativeLabResult.Positive, QualitativeLabResult.Positive)]
        [InlineData(QualitativeLabResult.Negative, QualitativeLabResult.Negative)]
        public void QualitativeLab_GivenResult_ReturnsCorrectClassification(
            QualitativeLabResult result, QualitativeLabResult expectedClassification)
        {
            PatientBuilder.Initialize()
                .SetGender(GenderIdentity.Male)
                .BuildWithoutModelValidation();

            var test = Qualitative.HepatitisCAntibody(result);

            var interp = new QualitativeLabClassification(test);

            var classification = interp.Classification;

            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void GivenNullQualitytativeTest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new QualitativeLabClassification(null));
        }
    }
}
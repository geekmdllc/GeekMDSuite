using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class QualitativeLabInterpretationTests
    {
        [Fact]
        public void Hiv_GivenPositive_ReturnsPositive()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var test = Qualitative.HepatitisCAntibody(QualitativeLabResult.Positive);

            var interp = new QualitativeLabInterpretation(test, mockPatient.Object);

            var classification = interp.Classification;

            Assert.Equal(QualitativeLabResult.Positive, classification);
        }
    }
}
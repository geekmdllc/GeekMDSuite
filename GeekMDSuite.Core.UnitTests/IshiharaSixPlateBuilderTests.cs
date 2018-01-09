using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
{
    public class IshiharaSixPlateBuilderTests
    {
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenTooFewPlates_ThrowsIndexOutOfRangeException()
        {
            var builder = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision);

            Assert.Throws<IndexOutOfRangeException>(() => builder.Build());
        }

        [Fact]
        public void IshiharaSixPlateInterpretation_GivenTooManyPlatesSet_DemonstratesToleranceAndSetsLatestValue()
        {
            var ishiharaSixPlate = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .SetPlate1(IshiharaAnswerResult.NormalVision) // extra, should not be added. overwrites previous
                .SetPlate4(IshiharaAnswerResult.NormalVision) // extra, should not be added. overwrites previous
                .Build();

            var assessment = new IshiharaSixPlateClassification(ishiharaSixPlate);
            Assert.Equal(IshiharaResultFlag.NormalVision, assessment.Classification);
            Assert.Equal(6, ishiharaSixPlate.GetAnswers().Count);
        }
    }
}
using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.UnitTests
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
            var answerList = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .SetPlate1(IshiharaAnswerResult.NormalVision) // extra, should not be added. overwrites previous
                .SetPlate4(IshiharaAnswerResult.NormalVision) // extra, should not be added. overwrites previous
                .Build();
            
            var assessment = new IshiharaSixPlateClassification(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.NormalVision, assessment.Classification);
            Assert.Equal(6,answerList.Count);
        }
    }
}
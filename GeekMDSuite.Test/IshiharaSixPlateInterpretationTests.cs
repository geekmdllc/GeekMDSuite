using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class IshiharaSixPlateInterpretationTests
    {
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenAllNormal_ReturnsNormalVision()
        {
            var answerList = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .Build();
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.NormalVision, assessment.Classification);
        }
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenOneAbnormal_ReturnsIndeterminantResult()
        {
            var answerList = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.IndeterminantResult, assessment.Classification);
        }
        
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenTwoAbnormal_ReturnsColorVisionDeficit()
        {
            var answerList = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.ColorVisionDeficit, assessment.Classification);
        }

        [Fact]
        public void NullAnswerList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IshiharaSixPlateInterpretation(null));
        }
    }
}
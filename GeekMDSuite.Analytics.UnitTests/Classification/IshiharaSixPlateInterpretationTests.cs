using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class IshiharaSixPlateInterpretationTests
    {
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenAllNormal_ReturnsNormalVision()
        {
            var ishiharaSixPlate = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .Build();
            
            var assessment = new IshiharaSixPlateClassification(ishiharaSixPlate);
            Assert.Equal(IshiharaResultFlag.NormalVision, assessment.Classification);
        }
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenOneAbnormal_ReturnsIndeterminantResult()
        {
            var ishiharaSixPlate = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();
            
            var assessment = new IshiharaSixPlateClassification(ishiharaSixPlate);
            Assert.Equal(IshiharaResultFlag.IndeterminantResult, assessment.Classification);
        }
        
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenTwoAbnormal_ReturnsColorVisionDeficit()
        {
            var ishiharaSixPlate = new IshiharaSixPlateScreenBuilder()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.NormalVision)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();
            
            var assessment = new IshiharaSixPlateClassification(ishiharaSixPlate);
            Assert.Equal(IshiharaResultFlag.ColorVisionDeficit, assessment.Classification);
        }

        [Fact]
        public void NullAnswerList_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new IshiharaSixPlateClassification(null));
        }
    }
}
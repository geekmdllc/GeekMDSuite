using System;
using System.Collections.Generic;
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
            var answerList = new List<IshiharaPlateAnswer>() {
                new IshiharaPlateAnswer(1, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(2, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(3, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(4, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(5, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(6, IshiharaAnswerResult.NormalVision)
            };
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.NormalVision, assessment.Classification);
        }
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenOneAbnormal_ReturnsIndeterminantResult()
        {
            var answerList = new List<IshiharaPlateAnswer>() {
                new IshiharaPlateAnswer(1, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(2, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(3, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(4, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(5, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(6, IshiharaAnswerResult.ColorVisionDefict)
            };
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.IndeterminantResult, assessment.Classification);
        }
        
        [Fact]
        public void IshiharaSixPlateInterpretation_GivenTwoAbnormal_ReturnsColorVisionDeficit()
        {
            var answerList = new List<IshiharaPlateAnswer>() {
                new IshiharaPlateAnswer(1, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(2, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(3, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(4, IshiharaAnswerResult.NormalVision),
                new IshiharaPlateAnswer(5, IshiharaAnswerResult.ColorVisionDefict),
                new IshiharaPlateAnswer(6, IshiharaAnswerResult.ColorVisionDefict)
            };
            
            var assessment = new IshiharaSixPlateInterpretation(answerList.GetRange(0,6));
            Assert.Equal(IshiharaResultFlag.ColorVisionDeficit, assessment.Classification);
        }
    }
}
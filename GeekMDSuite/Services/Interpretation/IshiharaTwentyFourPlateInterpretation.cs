using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    internal class IshiharaTwentyFourPlateInterpretation : IshiharaColorVisionInterpretation, IInterpretable<IshiharaResultFlag>
    {
        public IshiharaTwentyFourPlateInterpretation(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara24)
        {
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText Interpretation => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    internal class IshiharaThirtyEightPlateInterpretation : IshiharaColorVisionInterpretation, IInterpretable<IshiharaResultFlag>
    {
        public IshiharaThirtyEightPlateInterpretation(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara38)
        {
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText Interpretation => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
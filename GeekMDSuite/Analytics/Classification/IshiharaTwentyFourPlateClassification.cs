using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics
{
    internal class IshiharaTwentyFourPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _answerList;

        public IshiharaTwentyFourPlateClassification(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara24)
        {
            _answerList = answerList;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText InterpretationText => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
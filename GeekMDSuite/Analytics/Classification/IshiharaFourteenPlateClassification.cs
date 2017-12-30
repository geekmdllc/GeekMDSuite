using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics
{
    internal class IshiharaFourteenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _answerList;

        public IshiharaFourteenPlateClassification(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara14)
        {
            _answerList = answerList;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText InterpretationText => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics
{
    public class IshiharaSixPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _answerList;

        public IshiharaSixPlateClassification(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara6)
        {
            _answerList = answerList;
        }
        
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText InterpretationText => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
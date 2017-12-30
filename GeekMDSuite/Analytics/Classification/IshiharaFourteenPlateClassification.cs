using System.Collections.Generic;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaFourteenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _answerList;

        public IshiharaFourteenPlateClassification(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara14)
        {
            _answerList = answerList;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
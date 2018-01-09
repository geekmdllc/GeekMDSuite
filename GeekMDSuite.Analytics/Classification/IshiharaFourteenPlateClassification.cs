using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaFourteenPlateClassification : IshiharaColorVisionClassification,
        IClassifiable<IshiharaResultFlag>
    {
        public IshiharaFourteenPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate,
            IshiharaTestType.Ishihara14)
        {
        }

        public IshiharaResultFlag Classification => Classify();

        protected sealed override IshiharaResultFlag Classify()
        {
            return AssessIshiharaVisionAssessment();
        }
    }
}
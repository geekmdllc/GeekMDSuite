using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaTenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaTenPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate,
            IshiharaTestType.Ishihara10)
        {
        }

        public IshiharaResultFlag Classification => Classify();

        protected sealed override IshiharaResultFlag Classify()
        {
            return AssessIshiharaVisionAssessment();
        }
    }
}
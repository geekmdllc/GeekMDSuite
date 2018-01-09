using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaTwentyFourPlateClassification : IshiharaColorVisionClassification,
        IClassifiable<IshiharaResultFlag>
    {
        public IshiharaTwentyFourPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(
            ishiharaSixPlate, IshiharaTestType.Ishihara24)
        {
        }

        public IshiharaResultFlag Classification => Classify();

        protected sealed override IshiharaResultFlag Classify()
        {
            return AssessIshiharaVisionAssessment();
        }
    }
}
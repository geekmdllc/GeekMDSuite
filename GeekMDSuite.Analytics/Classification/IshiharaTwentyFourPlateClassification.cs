using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaTwentyFourPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaTwentyFourPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara24)
        {
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
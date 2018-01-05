using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaThirtyEightPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaThirtyEightPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara38)
        {
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
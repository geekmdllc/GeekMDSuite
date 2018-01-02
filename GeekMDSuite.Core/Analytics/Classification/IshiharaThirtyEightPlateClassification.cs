using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    internal class IshiharaThirtyEightPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _ishiharaSixPlate;

        public IshiharaThirtyEightPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara38)
        {
            _ishiharaSixPlate = ishiharaSixPlate;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
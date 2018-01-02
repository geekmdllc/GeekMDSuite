using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    internal class IshiharaFourteenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _ishiharaSixPlate;

        public IshiharaFourteenPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara14)
        {
            _ishiharaSixPlate = ishiharaSixPlate;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
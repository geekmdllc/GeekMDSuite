using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    internal class IshiharaTenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        private readonly List<IshiharaPlateAnswer> _ishiharaSixPlate;

        public IshiharaTenPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara10)
        {
            _ishiharaSixPlate = ishiharaSixPlate;
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    internal class IshiharaTenPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaTenPlateClassification(List<IshiharaPlateAnswer> ishiharaSixPlate) : base(ishiharaSixPlate, IshiharaTestType.Ishihara10)
        {
        }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public IshiharaResultFlag Classification => Classify();
    }
}
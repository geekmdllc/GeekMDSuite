using System;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class IshiharaSixPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaSixPlateClassification(IshiharaSixPlate ishiharaSixPlate) : base(ishiharaSixPlate.GetAnswers(), IshiharaTestType.Ishihara6)
        {
            if (ishiharaSixPlate.GetAnswers() == null) throw new NullReferenceException();
        }
        
        public IshiharaResultFlag Classification => Classify();
        
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();
    }
}
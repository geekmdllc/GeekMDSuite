using System;
using System.Linq;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class IshiharaSixPlateClassification : IshiharaColorVisionClassification, IClassifiable<IshiharaResultFlag>
    {
        public IshiharaSixPlateClassification(IshiharaSixPlate ishiharaSixPlate) : base(ishiharaSixPlate.GetAnswers(),
            IshiharaTestType.Ishihara6)
        {
            if (ishiharaSixPlate.GetAnswers() == null) throw new NullReferenceException();
        }

        public IshiharaResultFlag Classification => Classify();

        protected sealed override IshiharaResultFlag Classify()
        {
            return AssessIshiharaVisionAssessment();
        }
    }
}
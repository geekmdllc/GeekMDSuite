using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation
{
    public class IshiharaSixPlateInterpretation : IshiharaColorVisionInterpretation, IInterpretable<IshiharaResultFlag>
    {
        public IshiharaSixPlateInterpretation(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara6)
        {
            PlateSet = IshiharaPlateSetRepository.SixPlateScreen();
            if(answerList.Count != PlateSet.Count) 
                throw new IndexOutOfRangeException($"{nameof(answerList)} has {answerList.Count} items and it should have {PlateSet.Count}.");
        }
        
        protected sealed override List<IshiharaPlateModel> PlateSet { get; set; }
        protected sealed override IshiharaResultFlag Classify() => AssessIshiharaVisionAssessment();

        public InterpretationText Interpretation => throw new NotImplementedException();
        public IshiharaResultFlag Classification => Classify();
    }
}
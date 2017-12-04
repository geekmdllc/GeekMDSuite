using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionBaseExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        public BodyCompositionBaseExpandedInterpretation( 
            IBodyComposition bodyComposition, 
            double visceralFat, 
            double percentBodyFat) 
            : base(bodyComposition)
        {
            VisceralFat = visceralFat;
            PercentBodyFat = percentBodyFat;
        }

        public double VisceralFat { get; }
        public double PercentBodyFat { get; }

        public override InterpretationText Interpretation => throw new NotImplementedException();
        public BodyCompositionClassification Classification => throw new NotImplementedException();
    }
}
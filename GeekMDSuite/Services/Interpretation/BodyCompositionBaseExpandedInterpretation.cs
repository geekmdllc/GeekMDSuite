using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionBaseExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable
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
    }
}
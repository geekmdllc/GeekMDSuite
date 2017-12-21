using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        public BodyCompositionExpandedInterpretation( 
            IBodyCompositionExpanded bodyComposition) 
            : base(bodyComposition)
        {
            VisceralFat = bodyComposition.VisceralFat;
            PercentBodyFat = bodyComposition.PercentBodyFat;
        }

        public double VisceralFat { get; }
        public double PercentBodyFat { get; }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public BodyCompositionClassification Classification => Classify();

        public override string ToString() => Classification.ToString();

        protected override BodyCompositionClassification Classify() => throw new NotImplementedException();
        
        //TODO
        // Visceral Fat Interpretation: DONE
        // Percent Body Fat Interpretation
    }
}
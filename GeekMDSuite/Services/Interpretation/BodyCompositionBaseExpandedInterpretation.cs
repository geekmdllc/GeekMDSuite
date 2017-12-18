using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionBaseExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        public BodyCompositionBaseExpandedInterpretation( 
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
    }
}
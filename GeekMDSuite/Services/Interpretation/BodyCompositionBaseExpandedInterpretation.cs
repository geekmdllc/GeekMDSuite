using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionBaseExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        public BodyCompositionBaseExpandedInterpretation( 
            IBodyCompositionExpanded bodyCompositionExpanded) 
            : base(bodyCompositionExpanded)
        {
            VisceralFat = bodyCompositionExpanded.VisceralFat;
            PercentBodyFat = bodyCompositionExpanded.PercentBodyFat;
        }

        public double VisceralFat { get; }
        public double PercentBodyFat { get; }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public BodyCompositionClassification Classification => throw new NotImplementedException();

        public override string ToString() => Classification.ToString();
    }
}
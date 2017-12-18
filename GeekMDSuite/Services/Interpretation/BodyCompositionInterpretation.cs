using System;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {

        protected BodyCompositionInterpretation(IBodyComposition bodyCompositionExpanded) : base(bodyCompositionExpanded)
        {
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public BodyCompositionClassification Classification => throw new NotImplementedException();

        public override string ToString() => Classification.ToString();
    }
}
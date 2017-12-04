using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {

        protected BodyCompositionInterpretation(IBodyComposition bodyComposition) : base(bodyComposition)
        {
        }

        public sealed override InterpretationText Interpretation => throw new NotImplementedException();
        
        public BodyCompositionClassification Classification => throw new NotImplementedException();
    }

    public enum BodyCompositionClassification
    {
        Underweight,
        NormalWeight,
        OverWeight
    }
}
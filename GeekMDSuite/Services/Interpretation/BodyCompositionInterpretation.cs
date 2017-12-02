using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionInterpretation : BodyCompositionBaseInterpretation
    {

        protected BodyCompositionInterpretation(IBodyComposition bodyComposition) : base(bodyComposition)
        {
        }

        public sealed override InterpretationText Interpretation => throw new NotImplementedException();
    }
}
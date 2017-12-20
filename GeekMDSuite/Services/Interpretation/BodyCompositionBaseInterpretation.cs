using System;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionBaseInterpretation
    {
        protected BodyCompositionBaseInterpretation(IBodyComposition bodyComposition)
        {
            _bodyComposition = bodyComposition;
        }
        
        private IBodyComposition _bodyComposition;
        // TODO: Develop BodyCompositionBaseInterpretation
        // Hip to waist
        // Waist to height: DONE
        // BMI: DONE
        // Classify (needs new class)
        protected virtual BodyCompositionClassification Classify() => throw new NotImplementedException();
    }
}
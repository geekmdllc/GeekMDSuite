using System;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.MeasurementUnits;

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
        // Hip to height
        // BMI
        // Classify (needs new class)
        protected virtual BodyCompositionClassification Classify() => throw new NotImplementedException();
    }
}
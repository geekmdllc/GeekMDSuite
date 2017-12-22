using System;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {

        protected BodyCompositionInterpretation(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {
        }

        public InterpretationText Interpretation => throw new NotImplementedException();

        public BodyCompositionClassification Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
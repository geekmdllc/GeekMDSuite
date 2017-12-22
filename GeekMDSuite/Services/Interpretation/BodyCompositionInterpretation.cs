using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {

        public BodyCompositionInterpretation(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {
        }

        public InterpretationText Interpretation => throw new NotImplementedException();

        public BodyCompositionClassification Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
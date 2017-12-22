using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;

        public BodyCompositionInterpretation(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {
            _bodyComposition = bodyComposition;
            _patient = patient;
        }

        public InterpretationText Interpretation => throw new NotImplementedException();

        public BodyCompositionClassification Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
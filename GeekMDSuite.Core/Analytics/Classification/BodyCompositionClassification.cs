using System;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BodyCompositionClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionResult>
    {
        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;

        public BodyCompositionClassification(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public BodyCompositionResult Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
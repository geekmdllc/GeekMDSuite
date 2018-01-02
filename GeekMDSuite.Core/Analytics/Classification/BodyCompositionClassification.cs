namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BodyCompositionClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionResult>
    {
        public BodyCompositionClassification(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {

        }

        public BodyCompositionResult Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
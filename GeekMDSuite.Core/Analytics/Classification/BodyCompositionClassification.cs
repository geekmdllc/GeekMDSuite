namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BodyCompositionClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionClassificationResult>
    {
        public BodyCompositionClassification(IBodyComposition bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {

        }

        public BodyCompositionClassification()
        {
            
        }

        public BodyCompositionClassificationResult Classification => Classify();

        public override string ToString() => Classification.ToString();
    }
}
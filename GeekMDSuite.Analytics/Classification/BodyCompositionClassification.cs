using GeekMDSuite.Core;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionClassificationResult>
    {
        public BodyCompositionClassification(BodyComposition bodyComposition, Patient patient) 
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
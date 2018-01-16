namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionClassification : BodyCompositionBaseClassification,
        IClassifiable<BodyCompositionClassificationResult>
    {
        public BodyCompositionClassification(
            BodyCompositionClassificationParameters bodyCompositionClassificationParameters)
            : base(bodyCompositionClassificationParameters.BodyComposition,
                bodyCompositionClassificationParameters.Patient)
        {
        }

        public BodyCompositionClassification()
        {
        }

        public BodyCompositionClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }
    }
}
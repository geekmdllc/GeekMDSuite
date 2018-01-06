namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionClassificationResult
    {
        public BodyCompositionClassificationResult()
        {
        }

        public BodyCompositionClassificationResult(BodyCompositionResult bodyComposition)
        {
            BodyComposition = bodyComposition;
        }

        public BodyCompositionResult BodyComposition { get; }

        public static BodyCompositionClassificationResult Build(BodyCompositionResult bodyCompositionResult)
        {
            return new BodyCompositionClassificationResult(bodyCompositionResult);
        }
    }
}
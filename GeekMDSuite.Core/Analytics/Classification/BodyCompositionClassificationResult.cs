namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BodyCompositionClassificationResult
    {
        public BodyCompositionResult BodyComposition { get; }

        public BodyCompositionClassificationResult()
        {
            
        }

        public BodyCompositionClassificationResult(BodyCompositionResult bodyComposition)
        {
            BodyComposition = bodyComposition;
        }

        public static BodyCompositionClassificationResult Build(BodyCompositionResult bodyCompositionResult)
        {
            return new BodyCompositionClassificationResult(bodyCompositionResult);
        }
    }
}
namespace GeekMDSuite
{
    public class AudiogramClassificationResult
    {
        public AudiogramClassificationResult(HearingLoss classification, Laterality laterality, Laterality worstSide)
        {
            Classification = classification;
            Laterality = laterality;
            WorstSide = worstSide;
        }
        public HearingLoss Classification { get; }
        public Laterality Laterality { get; }
        public Laterality WorstSide { get; }
    }
}
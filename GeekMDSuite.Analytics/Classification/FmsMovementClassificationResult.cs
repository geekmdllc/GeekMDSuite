using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class FmsMovementClassificationResult
    {
        internal FmsMovementClassificationResult(FmsScoreFlag score, FmsRecommendedAction recommendedAction)
        {
            RecommendedAction = recommendedAction;
            Score = score;
        }

        public FmsRecommendedAction RecommendedAction { get; }
        public FmsScoreFlag Score { get; }
        public override string ToString() => $"Score: {Score}, Recommended Action: {RecommendedAction}";
    }
}
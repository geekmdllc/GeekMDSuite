using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class FmsMovementClassification
    {
        internal FmsMovementClassification(FmsScoreFlag score, FmsRecommendedAction recommendedAction)
        {
            RecommendedAction = recommendedAction;
            Score = score;
        }

        public FmsRecommendedAction RecommendedAction { get; }
        public FmsScoreFlag Score { get; }
    }
}
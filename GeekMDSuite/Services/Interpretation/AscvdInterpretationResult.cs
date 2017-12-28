namespace GeekMDSuite.Services.Interpretation
{
    public class AscvdInterpretationResult
    {
        public static AscvdInterpretationResult Build(
            AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation) => 
            new AscvdInterpretationResult(riskClassification, statinCandidacy, statinRecommendation, aspirinRecommendation);

        private AscvdInterpretationResult(AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation)
        {
            RiskClassification = riskClassification;
            StatinCandidacy = statinCandidacy;
            StatinRecommendation = statinRecommendation;
            AspirinRecommendation = aspirinRecommendation;
        }

        public AscvdRiskClassification RiskClassification { get; }
        public AscvdStatinCandidacy StatinCandidacy { get; }
        public AscvdStatinRecommendation StatinRecommendation { get; }
        public AscvdAspirinRecommendation AspirinRecommendation { get; }

        public override string ToString() => $"Risk: {RiskClassification}, Statin Candidacy: {StatinCandidacy}, " +
                                             $"Statin Recommendation: {StatinRecommendation}, " +
                                             $"Aspirin Recommendation: {AspirinRecommendation}";
    }
}
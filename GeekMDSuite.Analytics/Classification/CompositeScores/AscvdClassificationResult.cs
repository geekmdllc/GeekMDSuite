using System;
using System.Collections.Generic;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdClassificationResult
    {

        public static AscvdClassificationResult Build(
            AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors, 
            AscvdRiskClassification lifetime) => 
            new AscvdClassificationResult(
                riskClassification, 
                statinCandidacy, 
                statinRecommendation, 
                aspirinRecommendation, 
                riskFactors, 
                lifetime);

        private AscvdClassificationResult(AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors,
            AscvdRiskClassification lifetimeRisk)
        {
            AscvdLifetimeRisk = lifetimeRisk;
            RiskClassification = riskClassification;
            StatinCandidacy = statinCandidacy;
            StatinRecommendation = statinRecommendation;
            AspirinRecommendation = aspirinRecommendation;
            RiskFactors = riskFactors;
        }

        public AscvdRiskClassification AscvdLifetimeRisk { get; }
        public AscvdRiskClassification RiskClassification { get; }
        public AscvdStatinCandidacy StatinCandidacy { get; }
        public AscvdStatinRecommendation StatinRecommendation { get; }
        public AscvdAspirinRecommendation AspirinRecommendation { get; }
        public List<AscvdModifiableRiskFactors> RiskFactors { get; }

        public override string ToString() => $"Risk: {RiskClassification}, Statin Candidacy: {StatinCandidacy}, " +
                                             $"Statin Recommendation: {StatinRecommendation}, " +
                                             $"Aspirin Recommendation: {AspirinRecommendation}" + Environment.NewLine +
                                             "Risk Factors: " + string.Join(", ", RiskFactors) + Environment.NewLine +
                                             $"Lifetime Risk: {AscvdLifetimeRisk}";
    }
}
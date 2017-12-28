using System;
using System.Collections.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    public class AscvdInterpretationResult
    {
        public static AscvdInterpretationResult Build(
            AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors) => 
            new AscvdInterpretationResult(riskClassification, statinCandidacy, statinRecommendation, aspirinRecommendation, riskFactors);

        private AscvdInterpretationResult(AscvdRiskClassification riskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors)
        {
            RiskClassification = riskClassification;
            StatinCandidacy = statinCandidacy;
            StatinRecommendation = statinRecommendation;
            AspirinRecommendation = aspirinRecommendation;
            RiskFactors = riskFactors;
        }

        public AscvdRiskClassification RiskClassification { get; }
        public AscvdStatinCandidacy StatinCandidacy { get; }
        public AscvdStatinRecommendation StatinRecommendation { get; }
        public AscvdAspirinRecommendation AspirinRecommendation { get; }
        public List<AscvdModifiableRiskFactors> RiskFactors { get; }

        public override string ToString() => $"Risk: {RiskClassification}, Statin Candidacy: {StatinCandidacy}, " +
                                             $"Statin Recommendation: {StatinRecommendation}, " +
                                             $"Aspirin Recommendation: {AspirinRecommendation}" + Environment.NewLine +
                                             "Risk Factors: " + string.Join(", ", RiskFactors);
    }
}
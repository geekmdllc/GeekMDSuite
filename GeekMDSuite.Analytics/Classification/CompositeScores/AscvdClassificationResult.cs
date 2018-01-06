using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Tools.Cardiology;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdClassificationResult
    {
        internal AscvdClassificationResult()
        {
            RiskFactors = new List<AscvdModifiableRiskFactors>();
        }

        private AscvdClassificationResult(
            PooledCohortsEquation pooledCohortsEquation,
            AscvdRiskClassification tenYearTenYearRiskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors,
            AscvdRiskClassification lifetimeRiskClassification) : this()
        {
            PooledCohortsEquation = pooledCohortsEquation;
            LifetimeRiskClassification = lifetimeRiskClassification;
            TenYearRiskClassification = tenYearTenYearRiskClassification;
            StatinCandidacy = statinCandidacy;
            StatinRecommendation = statinRecommendation;
            AspirinRecommendation = aspirinRecommendation;
            RiskFactors = riskFactors;
        }

        public double TenYearRiskPercentage => PooledCohortsEquation.Ascvd10YearRiskPercentage;
        public double IdealTenYearRiskPercentage => PooledCohortsEquation.IdealAscvd10YearRiskPercentage;
        public AscvdRiskClassification TenYearRiskClassification { get; set; }
        public double LifetimeRiskPercentage => PooledCohortsEquation.AscvdLifetimeRiskPercentage;
        public double IdealLifetimeRiskPercentage => PooledCohortsEquation.IdealAscvdLifetimeRiskPercentage;
        public AscvdRiskClassification LifetimeRiskClassification { get; set; }
        public AscvdStatinCandidacy StatinCandidacy { get; set; }
        public AscvdStatinRecommendation StatinRecommendation { get; set; }
        public AscvdAspirinRecommendation AspirinRecommendation { get; set; }
        public List<AscvdModifiableRiskFactors> RiskFactors { get; set; }

        internal PooledCohortsEquation PooledCohortsEquation { get; set; }

        internal static AscvdClassificationResult Build(
            PooledCohortsEquation pooledCohortsEquation,
            AscvdRiskClassification tenYearRiskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors,
            AscvdRiskClassification lifetime)
        {
            return new AscvdClassificationResult(
                pooledCohortsEquation,
                tenYearRiskClassification,
                statinCandidacy,
                statinRecommendation,
                aspirinRecommendation,
                riskFactors,
                lifetime);
        }

        public override string ToString()
        {
            return $"10-yr Risk: {TenYearRiskPercentage}% ({TenYearRiskClassification} | " +
                   $"ideal: {IdealTenYearRiskPercentage}%), Statin Candidacy: {StatinCandidacy}, " +
                   $"Statin Recommendation: {StatinRecommendation}, " +
                   $"Aspirin Recommendation: {AspirinRecommendation}" + Environment.NewLine +
                   "Risk Factors: " + string.Join(", ", RiskFactors) + Environment.NewLine +
                   $"Lifetime Risk: {LifetimeRiskPercentage}% ({LifetimeRiskClassification} | " +
                   $"ideal: {IdealLifetimeRiskPercentage}%)";
        }
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Tools.Cardiology;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdClassificationResult
    {

        public static AscvdClassificationResult Build(
            PooledCohortsEquation pooledCohortsEquation,
            AscvdRiskClassification tenYearRiskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors, 
            AscvdRiskClassification lifetime) => 
            new AscvdClassificationResult(
                pooledCohortsEquation,
                tenYearRiskClassification, 
                statinCandidacy, 
                statinRecommendation, 
                aspirinRecommendation, 
                riskFactors, 
                lifetime);

        public double TenYearRiskPercentage => _pooledCohortsEquation.Ascvd10YearRiskPercentage;
        public double IdealTenYearRiskPercentage => _pooledCohortsEquation.IdealAscvd10YearRiskPercentage;
        public AscvdRiskClassification TenYearRiskClassification { get; }
        public double LifetimeRiskPercentage => _pooledCohortsEquation.AscvdLifetimeRiskPercentage;
        public double IdealLifetimeRiskPercentage => _pooledCohortsEquation.IdealAscvdLifetimeRiskPercentage;
        public AscvdRiskClassification LifetimeRiskClassification { get; }
        public AscvdStatinCandidacy StatinCandidacy { get; }
        public AscvdStatinRecommendation StatinRecommendation { get; }
        public AscvdAspirinRecommendation AspirinRecommendation { get; }
        public List<AscvdModifiableRiskFactors> RiskFactors { get; }

        public override string ToString() => $"10-yr Risk: {TenYearRiskPercentage}% ({TenYearRiskClassification} | " +
                                             $"ideal: {IdealTenYearRiskPercentage}%), Statin Candidacy: {StatinCandidacy}, " +
                                             $"Statin Recommendation: {StatinRecommendation}, " +
                                             $"Aspirin Recommendation: {AspirinRecommendation}" + Environment.NewLine +
                                             "Risk Factors: " + string.Join(", ", RiskFactors) + Environment.NewLine +
                                             $"Lifetime Risk: {LifetimeRiskPercentage}% ({LifetimeRiskClassification} | " +
                                             $"ideal: {IdealLifetimeRiskPercentage}%)";
        
        private AscvdClassificationResult(
            PooledCohortsEquation pooledCohortsEquation,
            AscvdRiskClassification tenYearTenYearRiskClassification,
            AscvdStatinCandidacy statinCandidacy,
            AscvdStatinRecommendation statinRecommendation,
            AscvdAspirinRecommendation aspirinRecommendation,
            List<AscvdModifiableRiskFactors> riskFactors,
            AscvdRiskClassification lifetimeRiskClassification)
        {
            _pooledCohortsEquation = pooledCohortsEquation;
            LifetimeRiskClassification = lifetimeRiskClassification;
            TenYearRiskClassification = tenYearTenYearRiskClassification;
            StatinCandidacy = statinCandidacy;
            StatinRecommendation = statinRecommendation;
            AspirinRecommendation = aspirinRecommendation;
            RiskFactors = riskFactors;
        }
        
        
        private readonly PooledCohortsEquation _pooledCohortsEquation;
    }
}
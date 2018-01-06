using System;
using System.Collections.Generic;
using System.Text;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core.Builders;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    internal class AscvdClassificationResultBuilder : Builder<AscvdClassificationResultBuilder, AscvdClassificationResult>
    {
        public override AscvdClassificationResult Build()
        {
            ValidatePreBuildState();
            return AscvdClassificationResult.Build(
                    _pooledCohortsEquation,
                    _tenYearRiskClassification,
                    _statinCandidacy,
                    _statinRecommendation,
                    _aspirinRecommendation,
                    _riskFactors,
                    _lifetimeRiskClassification
                );
        }

        public override AscvdClassificationResult BuildWithoutModelValidation()
        {
            return new AscvdClassificationResult()
            {
                PooledCohortsEquation = _pooledCohortsEquation,
                RiskFactors = _riskFactors,
                AspirinRecommendation = _aspirinRecommendation,
                LifetimeRiskClassification = _lifetimeRiskClassification,
                StatinCandidacy = _statinCandidacy,
                StatinRecommendation = _statinRecommendation,
                TenYearRiskClassification = _tenYearRiskClassification
            };
        }

        public AscvdClassificationResultBuilder SetPooledCohortsEquation(PooledCohortsEquation pooledCohortsEquation)
        {
            _pooledCohortsEquation = pooledCohortsEquation;
            return this;
        }
        public AscvdClassificationResultBuilder SetTenYearRiskClassification(AscvdRiskClassification tenYearRiskClassification)
        {
            _tenYearRiskClassificationIsSet = true;
            _tenYearRiskClassification = tenYearRiskClassification;
            return this;
        }
        
        public AscvdClassificationResultBuilder SetLifetimeRiskClassification(AscvdRiskClassification lifetimeRiskClassification)
        {
            _lifetimeRiskClassificationIsSet = true;
            _lifetimeRiskClassification = lifetimeRiskClassification;
            return this;
        }
        public AscvdClassificationResultBuilder SetStatinCandidacy(AscvdStatinCandidacy statinCandidacy)
        {
            _statinCandidacyIsSet = true;
            _statinCandidacy = statinCandidacy;
            return this;
        }
        public AscvdClassificationResultBuilder SetStatinRecommendations(AscvdStatinRecommendation statinRecommendation)
        {
            _statinRecommendationIsSet = true;
            _statinRecommendation = statinRecommendation;
            return this;
        }
        public AscvdClassificationResultBuilder SetAspirinRecommendation(AscvdAspirinRecommendation aspirinRecommendation)
        {
            _aspirinRecommendationIsSet = true;
            _aspirinRecommendation = aspirinRecommendation;
            return this;
        }
        public AscvdClassificationResultBuilder SetRiskFactors(List<AscvdModifiableRiskFactors> riskFactors)
        {
            _riskFactorsAreSet = true;
            _riskFactors = riskFactors;
            return this;
        }
        
        
        private PooledCohortsEquation _pooledCohortsEquation;
        private bool _tenYearRiskClassificationIsSet;
        private AscvdRiskClassification _tenYearRiskClassification;
        private bool _lifetimeRiskClassificationIsSet;
        private AscvdRiskClassification _lifetimeRiskClassification;
        private bool _statinCandidacyIsSet;
        private AscvdStatinCandidacy _statinCandidacy;
        private bool _statinRecommendationIsSet;
        private AscvdStatinRecommendation _statinRecommendation;
        private bool _aspirinRecommendationIsSet;
        private AscvdAspirinRecommendation _aspirinRecommendation;
        private bool _riskFactorsAreSet;
        private List<AscvdModifiableRiskFactors> _riskFactors = new List<AscvdModifiableRiskFactors>();
        
        
        private void ValidatePreBuildState()
        {
            var builder = new StringBuilder();
            if (_pooledCohortsEquation == null) builder.Append(nameof(SetPooledCohortsEquation));
            if (!_tenYearRiskClassificationIsSet) builder.Append(nameof(SetTenYearRiskClassification));
            if (!_lifetimeRiskClassificationIsSet) builder.Append(nameof(SetLifetimeRiskClassification));
            if (!_statinCandidacyIsSet) builder.Append(nameof(SetStatinCandidacy));
            if (!_statinRecommendationIsSet) builder.Append(nameof(SetStatinRecommendations));
            if (!_aspirinRecommendationIsSet) builder.Append(nameof(SetAspirinRecommendation));
            if (!_riskFactorsAreSet) builder.Append(nameof(SetRiskFactors));

            var message = builder.ToString();
            if(!string.IsNullOrWhiteSpace(message))
                throw new MissingMethodException(message);
        }
    }
}
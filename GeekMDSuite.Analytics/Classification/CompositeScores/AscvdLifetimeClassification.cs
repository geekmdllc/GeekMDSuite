using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;
using PooledCohortsEquation = GeekMDSuite.Analytics.Tools.Cardiology.PooledCohortsEquation;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    internal class AscvdLifetimeClassification : IClassifiable<AscvdRiskClassification>
    {
        public AscvdLifetimeClassification(double riskPercentage, Patient patient)
        {
            _patient = patient;
            _riskPercentage = riskPercentage;
        }
        
        public AscvdRiskClassification Classification => Classify();

        public override string ToString() => Classification.ToString();

        private readonly double _riskPercentage;
        private readonly Patient _patient;

        private AscvdRiskClassification Classify()
        {
            if (Gender.IsGenotypeXy(_patient.Gender) && _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Male.Optimal ||
                Gender.IsGenotypeXx(_patient.Gender) && _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Female.Optimal)
                return AscvdRiskClassification.Low;

            return AscvdRiskClassification.Elevated;
        }
    }
}
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    internal class AscvdLifetimeClassification : IClassifiable<AscvdRiskClassification>
    {
        private readonly Patient _patient;

        private readonly double _riskPercentage;

        public AscvdLifetimeClassification(double riskPercentage, Patient patient)
        {
            _patient = patient;
            _riskPercentage = riskPercentage;
        }

        public AscvdRiskClassification Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private AscvdRiskClassification Classify()
        {
            if (Gender.IsGenotypeXy(_patient.Gender) &&
                _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Male.Optimal ||
                Gender.IsGenotypeXx(_patient.Gender) &&
                _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Female.Optimal)
                return AscvdRiskClassification.Low;

            return AscvdRiskClassification.Elevated;
        }
    }
}
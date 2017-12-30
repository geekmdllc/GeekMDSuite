using GeekMDSuite.Tools.Cardiology;

namespace GeekMDSuite.Analytics.Classification
{
    public class AscvdLifetimeClassification : IClassifiable<AscvdRiskClassification>
    {
        public AscvdLifetimeClassification(double riskPercentage, IPatient patient)
        {
            _patient = patient;
            _riskPercentage = riskPercentage;
        }
        
        public AscvdRiskClassification Classification => Classify();

        public override string ToString() => Classification.ToString();

        private readonly double _riskPercentage;
        private readonly IPatient _patient;

        private AscvdRiskClassification Classify()
        {
            if (Gender.IsGenotypeXy(_patient.Gender) && _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Male.Optimal ||
                Gender.IsGenotypeXx(_patient.Gender) && _riskPercentage <= PooledCohortsEquation.AscvdLifetimeRiskPercentages.Female.Optimal)
                return AscvdRiskClassification.Low;

            return AscvdRiskClassification.Elevated;
        }
    }
}
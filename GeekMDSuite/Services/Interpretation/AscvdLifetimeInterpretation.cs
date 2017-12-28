using System;
using static GeekMDSuite.Tools.Cardiology.PooledCohortsEquation.AscvdLifetimeRiskPercentages;

namespace GeekMDSuite.Services.Interpretation
{
    public class AscvdLifetimeInterpretation : IInterpretable<AscvdRiskClassification>
    {
        public AscvdLifetimeInterpretation(double riskPercentage, IPatient patient)
        {
            _patient = patient;
            _riskPercentage = riskPercentage;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public AscvdRiskClassification Classification => Classify();
        
        private readonly double _riskPercentage;
        private readonly IPatient _patient;

        private AscvdRiskClassification Classify()
        {
            if (Gender.IsGenotypeXy(_patient.Gender) && _riskPercentage <= Male.Optimal ||
                Gender.IsGenotypeXx(_patient.Gender) && _riskPercentage <= Female.Optimal)
                return AscvdRiskClassification.Low;

            return AscvdRiskClassification.Elevated;
        }
    }
}
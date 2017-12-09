using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class CentralBloodPressureInterpretation : IInterpretable<CentralBloodPressureCategory>
    {
        public CentralBloodPressureInterpretation(CentralBloodPressure centralBloodPressure, IPatient patient)
        {
            _centralBloodPressure = centralBloodPressure;
            _patient = patient;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public CentralBloodPressureCategory Classification => throw new NotImplementedException();

        private CentralBloodPressure _centralBloodPressure;
        private IPatient _patient;
    }
}
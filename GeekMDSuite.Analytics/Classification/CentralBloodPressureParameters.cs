using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class CentralBloodPressureParameters
    {
        public CentralBloodPressureParameters(CentralBloodPressure centralBloodPressure, Patient patient)
        {
            CentralBloodPressure = centralBloodPressure;
            Patient = patient;
        }

        public CentralBloodPressure CentralBloodPressure { get; }
        public Patient Patient { get; }
    }
}
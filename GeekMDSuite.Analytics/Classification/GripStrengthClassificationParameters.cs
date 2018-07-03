using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthClassificationParameters
    {
        public GripStrengthClassificationParameters(GripStrength gripStrength, Patient patient)
        {
            GripStrength = gripStrength;
            Patient = patient;
        }

        public GripStrength GripStrength { get; }
        public Patient Patient { get; }
    }
}
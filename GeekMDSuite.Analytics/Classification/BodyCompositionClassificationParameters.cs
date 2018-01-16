using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionClassificationParameters
    {
        public BodyCompositionClassificationParameters(BodyComposition bodyComposition, Patient patient)
        {
            BodyComposition = bodyComposition;
            Patient = patient;
        }

        public BodyComposition BodyComposition { get; }
        public Patient Patient { get; }
    }
}
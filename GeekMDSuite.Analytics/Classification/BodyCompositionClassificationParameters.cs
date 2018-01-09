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

        public BodyComposition BodyComposition { get; private set; }
        public Patient Patient { get; private set; }
    }
}
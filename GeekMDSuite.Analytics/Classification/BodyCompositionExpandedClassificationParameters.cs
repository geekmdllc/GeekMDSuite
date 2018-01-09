using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionExpandedClassificationParameters
    {
        public BodyCompositionExpandedClassificationParameters(BodyCompositionExpanded bodyCompositionExpanded, Patient patient)
        {
            BodyCompositionExpanded = bodyCompositionExpanded;
            Patient = patient;
        }

        public BodyCompositionExpanded BodyCompositionExpanded { get; private set; }
        public Patient Patient { get; private set; }
    }
}
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SpirometryClassificationParameters
    {
        public SpirometryClassificationParameters(Spirometry spirometry, Patient patient, BodyComposition bodyComposition)
        {
            Spirometry = spirometry;
            Patient = patient;
            BodyComposition = bodyComposition;
        }

        public Spirometry Spirometry { get; private set; }
        public Patient Patient { get; private set; }
        public BodyComposition BodyComposition { get; private set; }
    }
}
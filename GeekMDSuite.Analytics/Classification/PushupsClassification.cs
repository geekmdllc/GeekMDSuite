namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassification : MuscularStrengthClassification
    {
        public PushupsClassification(MuscularStrengthClassificationParameters parameters) : base(parameters.Test, parameters.Patient)
        {
        }
    }
}
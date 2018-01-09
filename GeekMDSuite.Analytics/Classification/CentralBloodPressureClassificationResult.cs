namespace GeekMDSuite.Analytics.Classification
{
    public class CentralBloodPressureClassificationResult
    {
        public CentralBloodPressureClassificationResult(CentralBloodPressureCategory category,
            CentralBloodPressureReferenceAge referenceAge)
        {
            Category = category;
            ReferenceAge = referenceAge;
        }

        public CentralBloodPressureCategory Category { get; }
        public CentralBloodPressureReferenceAge ReferenceAge { get; }

        public override string ToString()
        {
            return $"Category: {Category}, Reference Age: {ReferenceAge}";
        }
    }
}
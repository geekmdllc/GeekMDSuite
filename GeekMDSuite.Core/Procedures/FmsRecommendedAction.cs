namespace GeekMDSuite.Core.Procedures
{
    public enum FmsRecommendedAction {
        Unrestricted,     // 3,3 and 2,2 scores
        Caution,          // 3,2 and 2,3 scores 
        Restricted,       // 1,1; 1,2; 1,3 scores
        MedicalAttention, // 0's anywhere
    }
}
namespace GeekMDSuite.Core.Procedures
{
    public interface IMuscularStrengthTest
    {
        double Value { get; set; }
        MuscularStrengthTest Type { get; }
    }
}
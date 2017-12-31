namespace GeekMDSuite.Procedures
{
    public interface IMuscularStrengthTest
    {
        double Value { get; set; }
        MuscularStrengthTest Type { get; }
    }
}
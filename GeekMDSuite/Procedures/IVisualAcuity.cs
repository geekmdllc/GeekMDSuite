namespace GeekMDSuite.Procedures
{
    public interface IVisualAcuity
    {
        int Distance { get; }
        int Near { get; }
        int Both { get; }
    }
}
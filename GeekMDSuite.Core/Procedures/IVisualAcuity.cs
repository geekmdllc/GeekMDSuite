namespace GeekMDSuite.Core.Procedures
{
    public interface IVisualAcuity
    {
        int Distance { get; set; }
        int Near { get; set; }
        int Both { get; set; }
    }
}
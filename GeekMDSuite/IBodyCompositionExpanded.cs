namespace GeekMDSuite
{
    public interface IBodyCompositionExpanded : IBodyComposition
    {
        double VisceralFat { get; }
        double PercentBodyFat { get; }
    }
}
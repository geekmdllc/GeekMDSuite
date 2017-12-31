namespace GeekMDSuite
{
    public interface IBodyCompositionExpanded : IBodyComposition
    {
        double VisceralFat { get; set; }
        double PercentBodyFat { get; set; }
    }
}
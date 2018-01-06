namespace GeekMDSuite.Analytics.Classification
{
    public interface IClassifiable<out T>
    {
        T Classification { get; }
    }
}
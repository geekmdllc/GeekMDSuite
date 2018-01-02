namespace GeekMDSuite.Core.Analytics.Classification
{
    public interface IClassifiable<out T>
    {        
        T Classification { get; }
    }
}
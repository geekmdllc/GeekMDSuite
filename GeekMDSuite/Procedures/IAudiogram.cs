namespace GeekMDSuite.Procedures
{
    public interface IAudiogram
    {
        IAudiogramDataset Right { get; }
        IAudiogramDataset Left { get; }
    }
}
namespace GeekMDSuite.Procedures
{
    public interface IAudiogram
    {
        AudiogramDataset Right { get; set; }
        AudiogramDataset Left { get; set; }
    }
}
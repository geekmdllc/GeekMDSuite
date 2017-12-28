namespace GeekMDSuite.Procedures
{
    public interface IAudiogramDataset
    {
        AudiogramDatapoint F125 { get; }
        AudiogramDatapoint F250 { get; }
        AudiogramDatapoint F500 { get; }
        AudiogramDatapoint F1000 { get; }
        AudiogramDatapoint F2000 { get; }
        AudiogramDatapoint F3000 { get; }
        AudiogramDatapoint F4000 { get; }
        AudiogramDatapoint F6000 { get; }
        AudiogramDatapoint F8000 { get; }
    }
}
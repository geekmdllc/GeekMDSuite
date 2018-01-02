namespace GeekMDSuite.Core.Procedures
{
    public interface IAudiogramDataset
    {
        AudiogramDatapoint F125 { get; set; }
        AudiogramDatapoint F250 { get; set; }
        AudiogramDatapoint F500 { get; set; }
        AudiogramDatapoint F1000 { get; set; }
        AudiogramDatapoint F2000 { get; set; }
        AudiogramDatapoint F3000 { get; set; }
        AudiogramDatapoint F4000 { get; set; }
        AudiogramDatapoint F6000 { get; set; }
        AudiogramDatapoint F8000 { get; set; }
    }
}
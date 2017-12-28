using GeekMDSuite.Procedures;

namespace GeekMDSuite.WebAPI.Models
{
    public class AudiogramEntity :  IEntity, IAudiogram
    {
        public int Id { get; set; }
        public IAudiogramDataset Right { get; set; }
        public IAudiogramDataset Left { get; set; }
    }
}
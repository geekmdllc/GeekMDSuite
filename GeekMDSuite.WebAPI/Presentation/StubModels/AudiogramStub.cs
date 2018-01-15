using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class AudiogramStub 
    {
        public int Id { get; set; }
        public AudiogramDataset Left { get; set; }
        public AudiogramDataset Right { get; set; }

        public AudiogramStub()
        {
            Left = new AudiogramDataset();
            Right = new AudiogramDataset();
        }
    }
}
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class AudiogramStubFromUser
    {
        public int Id { get; set; }
        public AudiogramDataset Left { get; set; }
        public AudiogramDataset Right { get; set; }

        public AudiogramStubFromUser()
        {
            Left = new AudiogramDataset();
            Right = new AudiogramDataset();
        }
    }
}
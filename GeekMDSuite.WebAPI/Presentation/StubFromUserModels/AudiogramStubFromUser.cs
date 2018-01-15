using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class AudiogramStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public AudiogramDataset Left { get; set; }
        public AudiogramDataset Right { get; set; }

        public AudiogramStubFromUser()
        {
            Left = new AudiogramDataset();
            Right = new AudiogramDataset();
        }
    }
}
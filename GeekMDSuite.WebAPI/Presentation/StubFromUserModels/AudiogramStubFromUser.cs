using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class AudiogramStubFromUser : IVisitData
    {
        public AudiogramStubFromUser()
        {
            Left = new AudiogramDataset();
            Right = new AudiogramDataset();
        }

        public AudiogramDataset Left { get; set; }
        public AudiogramDataset Right { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
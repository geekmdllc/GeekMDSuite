using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class AudiogramStubFromUser : IVisitData
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
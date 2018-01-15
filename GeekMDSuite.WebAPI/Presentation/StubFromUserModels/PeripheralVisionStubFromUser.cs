using System;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class PeripheralVisionStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
using System;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VisualAcuityStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }
    }
}
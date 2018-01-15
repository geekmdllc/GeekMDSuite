using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class VisualAcuityStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }
    }
}
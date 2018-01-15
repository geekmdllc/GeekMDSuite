using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class PeripheralVistionStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
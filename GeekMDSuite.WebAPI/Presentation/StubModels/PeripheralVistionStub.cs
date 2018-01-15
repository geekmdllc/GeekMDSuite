using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class PeripheralVistionStub : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
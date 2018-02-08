using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class PeripheralVisionStub : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
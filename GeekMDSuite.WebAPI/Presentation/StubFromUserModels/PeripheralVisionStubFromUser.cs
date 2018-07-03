using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class PeripheralVisionStubFromUser : IVisitData
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
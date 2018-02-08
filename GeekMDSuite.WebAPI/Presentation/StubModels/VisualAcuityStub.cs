using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class VisualAcuityStub : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }
    }
}
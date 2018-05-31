using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VisualAcuityStubFromUser : IVisitData
    {
        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
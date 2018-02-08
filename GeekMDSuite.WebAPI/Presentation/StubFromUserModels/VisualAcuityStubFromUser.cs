using System;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VisualAcuityStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }
    }
}
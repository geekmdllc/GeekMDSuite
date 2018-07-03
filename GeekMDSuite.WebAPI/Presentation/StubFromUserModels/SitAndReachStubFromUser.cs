using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class SitAndReachStubFromUser : IVisitData
    {
        public double Value { get; set; }
        public StrengthTest Type { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
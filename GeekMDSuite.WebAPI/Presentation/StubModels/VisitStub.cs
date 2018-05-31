using System;
using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class VisitStub
    {
        public Guid VisitGuid { get; set; }
        public DateTime Date { get; set; }
        public VisitStatus Status { get; set; }
        public Guid PatientGuid { get; set; }
    }
}
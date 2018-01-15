using System;
using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VisitStubFromUser
    {
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public VisitStatus Status { get; set; }
        public Guid PatientGuid { get; set; }
    }
}
using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class VisitStub
    {
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public VisitStatus Status { get; set; }
        public Guid PatientGuid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class PatientResource : ResourceModel
    {
        public PatientStub Patient { get; set; }
        public List<VisitStub> Visits { get; set; }
    }
}
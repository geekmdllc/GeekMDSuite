using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class VisitResource : ResourceModel
    {
        public VisitStub Visit { get; set; }
        public PatientStub Patient { get; set; }
        
    }
}
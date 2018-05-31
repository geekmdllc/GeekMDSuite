﻿using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class PatientResource : Resource<PatientStub>
    {
        public PatientResource()
        {
            Visits = new List<VisitStub>();
        }

        public List<VisitStub> Visits { get; set; }
    }
}
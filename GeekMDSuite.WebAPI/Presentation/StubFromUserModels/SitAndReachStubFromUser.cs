﻿using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class SitAndReachStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double Value { get; set; }
        public StrengthTest Type { get; set; }
    }
}
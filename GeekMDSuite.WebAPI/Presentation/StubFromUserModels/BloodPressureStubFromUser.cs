﻿using System;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class BloodPressureStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }
    }
}
using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class BloodPressureStub : IVisitData
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
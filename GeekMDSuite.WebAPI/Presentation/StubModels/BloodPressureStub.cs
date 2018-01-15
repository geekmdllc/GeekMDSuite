using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class BloodPressureStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }
    }
}
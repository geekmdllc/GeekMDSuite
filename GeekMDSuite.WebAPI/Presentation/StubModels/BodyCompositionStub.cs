using System;
using GeekMDSuite.Utilities.MeasurementUnits;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class BodyCompositionStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Height Height { get; set; }
        public Waist Waist { get; set; }
        public Hips Hips { get; set; }
        public Weight Weight { get; set; }

        public BodyCompositionStub()
        {
            Height = new Height();
            Waist = new Waist();
            Hips = new Hips();
            Weight = new Weight();
        }
    }
}
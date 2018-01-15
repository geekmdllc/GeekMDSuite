using System;
using GeekMDSuite.Utilities.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class BodyCompositionExpandedStub : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Height Height { get; set; }
        public Waist Waist { get; set; }
        public Hips Hips { get; set; }
        public Weight Weight { get; set; }
        public double VisceralFat { get; set; }
        public double PercentBodyFat { get; set; }

        public BodyCompositionExpandedStub()
        {
            Height = new Height();
            Waist = new Waist();
            Hips = new Hips();
            Weight = new Weight();
        }
    }
}
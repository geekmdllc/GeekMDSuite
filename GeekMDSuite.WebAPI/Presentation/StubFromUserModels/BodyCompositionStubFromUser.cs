using System;
using GeekMDSuite.Utilities.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class BodyCompositionStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Height Height { get; set; }
        public Waist Waist { get; set; }
        public Hips Hips { get; set; }
        public Weight Weight { get; set; }

        public BodyCompositionStubFromUser()
        {
            Height = new Height();
            Waist = new Waist();
            Hips = new Hips();
            Weight = new Weight();
        }
    }
}
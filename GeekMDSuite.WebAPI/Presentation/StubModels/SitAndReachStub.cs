using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class SitAndReachStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double Value { get; set; }
        public StrengthTest Type { get; set; }
    }
}
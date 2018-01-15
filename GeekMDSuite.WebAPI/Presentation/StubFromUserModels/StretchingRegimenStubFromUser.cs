using System;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class StretchingRegimenStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
    }
}
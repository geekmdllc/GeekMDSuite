using System;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class StretchingRegimenStub : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
    }
}
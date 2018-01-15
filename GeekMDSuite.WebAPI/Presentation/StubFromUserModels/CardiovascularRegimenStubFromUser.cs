using System;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class CardiovascularRegimenStubFromUser
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
    }
}
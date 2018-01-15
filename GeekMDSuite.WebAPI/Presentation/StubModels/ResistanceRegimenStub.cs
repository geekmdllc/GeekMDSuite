using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class ResistanceRegimenStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int SecondsRestDurationPerSet { get; set; }
        public List<ResistenceRegimenFeatures> Features { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }

        public ResistanceRegimenStub()
        {
            Features = new List<ResistenceRegimenFeatures>();
        }
    }
}
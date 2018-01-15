using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class ResistanceRegimenStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int SecondsRestDurationPerSet { get; set; }
        public List<ResistenceRegimenFeatures> Features { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }

        public ResistanceRegimenStubFromUser()
        {
            Features = new List<ResistenceRegimenFeatures>();
        }
    }
}
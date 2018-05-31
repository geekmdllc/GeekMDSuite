using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class ResistanceRegimenStub : IVisitData
    {
        public ResistanceRegimenStub()
        {
            Features = new List<ResistenceRegimenFeatures>();
        }

        public int SecondsRestDurationPerSet { get; set; }
        public List<ResistenceRegimenFeatures> Features { get; set; }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}
using System.Collections.Generic;

namespace GeekMDSuite.PatientActivities
{
    public class ResistanceRegimen : ExerciseRegimen
    {
        public ResistanceRegimen(
            IExerciseRegimenParameters regimen, 
            int secondsRestDurationPerSet, 
            List<ResistenceRegimenFeatures> features) 
            : base(regimen.SessionsPerWeek, 
                regimen.AverageSessionDuration, 
                regimen.Intensity)
        {
            SecondsRestDurationPerSet = secondsRestDurationPerSet;
            Features = features;
        }
        public int SecondsRestDurationPerSet { get; }
        public List<ResistenceRegimenFeatures> Features { get; }
    }
}
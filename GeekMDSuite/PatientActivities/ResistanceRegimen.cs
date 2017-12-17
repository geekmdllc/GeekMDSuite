using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.PatientActivities
{
    public class ResistanceRegimen : ExerciseRegimen
    {
        internal ResistanceRegimen(
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
        
        public override string ToString()
        {
            return base.ToString() + " " + ListFeatures();
        }

        private string ListFeatures() => 
            Features.Aggregate(string.Empty, (current, feature) => current + $"{feature} ");
    }
}
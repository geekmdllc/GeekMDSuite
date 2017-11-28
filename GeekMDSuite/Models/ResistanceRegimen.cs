using System.Collections.Generic;
using GeekMDSuite.Services;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Models
{
    public class ResistanceRegimen : ExerciseRegimenBase
    {
        public ResistanceRegimen(
            ExerciseRegimenBase baseRegimen,
            int secondsRestDurationPerSet,
            List<ResistenceRegimenFeatures> regimenFeatures = null) 
            : base(baseRegimen.SessionsPerWeek, baseRegimen.AverageSessionDuration, baseRegimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Resistance);
            RestIntervalGoalRange = GetExerciseGoalValues.ResistanceRestInterval();
            SecondsRestDurationPerSet = secondsRestDurationPerSet;
            Features = regimenFeatures ?? new List<ResistenceRegimenFeatures>();
        }
        
        public int SecondsRestDurationPerSet { get; }
        public List<ResistenceRegimenFeatures> Features { get; set; }
        public Interval<int> RestIntervalGoalRange { get; }
        public sealed override ExerciseDurationGoals Goals { get; set; }
    }
}
using System.Collections.Generic;

namespace GeekMDSuite.Common.Models
{
    public class ResistanceRegimen : ExerciseRegimenBase
    {
        public int SecondsRestDurationPerSet { get; set; }
        public List<ResistenceRegimenFeatures> Features { get; set; }

        public ResistanceRegimen(
            double sessionsPerWeek, 
            double averageSessionDuration, 
            ExerciseIntensity intensity) 
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
            Goals = new ExerciseDurationGoals
            {
                HighIntensity = 90,
                ModerateIntensity = 120
            };
        }

        public sealed override ExerciseDurationGoals Goals { get; protected set; }
    }
}
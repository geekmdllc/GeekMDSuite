using System;

namespace GeekMDSuite
{
    public class ExerciseRegimenBase : IExerciseRegimen
    {
        public ExerciseRegimenBase (double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        
        public virtual ExerciseDurationGoals Goals => throw new NotImplementedException();
        
        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;
        
        public virtual bool RegimenIsAdequate => DurationAndIntensityAreAdequate;

        public static double GoalMinutesHighIntensity => 
            GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity => 
            GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).ModerateIntensity;
        
        public bool IntensityIsAdequate => IsHighIntensity || IsModerateIntensity;

        public bool DurationIsAdequate => IntensityIsAdequate && TimeGoalOrHigher;

        public double DurationPercentOfGoalAchieved =>
            GoalMinutes >= 0 ? 100 * TotalMinutes / GoalMinutes : 0;
        
        protected bool DurationAndIntensityAreAdequate => DurationIsAdequate && IntensityIsAdequate;
        
        protected bool TimeGoalOrHigher => TotalMinutes >= GoalMinutes;

        protected bool TimeAspirationalOrHigher => TotalMinutes >= GoalMinutes * 2;

        private bool IsModerateIntensity => Intensity == ExerciseIntensity.Moderate;

        private bool IsHighIntensity => (Intensity == ExerciseIntensity.High || Intensity == ExerciseIntensity.Vigorous);
        
        private double GoalMinutes {
            get
            {
                if (IsHighIntensity) return Goals.HighIntensity;
            
                return IsModerateIntensity ? Goals.ModerateIntensity : 0;
            }
        }
    }
}
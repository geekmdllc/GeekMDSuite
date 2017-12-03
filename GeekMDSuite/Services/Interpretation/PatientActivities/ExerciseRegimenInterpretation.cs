using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Fitness;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public abstract class ExerciseRegimenInterpretation : IExerciseRegimenClassification
    {
        protected ExerciseRegimenInterpretation (IExerciseRegimenParameters parameters)
        {
            SessionsPerWeek = parameters.SessionsPerWeek;
            AverageSessionDuration = parameters.AverageSessionDuration;
            Intensity = parameters.Intensity;
        }

        public virtual ExerciseRegimenClassification Classification => throw new NotImplementedException();

        public virtual ExerciseDurationGoals Goals => throw new NotImplementedException();
        
        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;
        
        public virtual bool RegimenIsAdequate => DurationAndIntensityAreAdequate;

        public static double GoalMinutesHighIntensity => 
            GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity => 
            GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).ModerateIntensity;
        
        public bool IntensityIsAdequate => IsHighIntensity || IsModerateIntensity;

        public bool DurationIsAdequate => IntensityIsAdequate && TimeGoalOrHigher;

        public double DurationPercentOfGoalAchieved =>
            GoalMinutes >= 0 ? 100 * TotalMinutes / GoalMinutes : 0;
        
        protected bool DurationAndIntensityAreAdequate => DurationIsAdequate && IntensityIsAdequate;
        
        protected bool TimeGoalOrHigher => TotalMinutes >= GoalMinutes;

        protected bool TimeAspirationalOrHigher => TotalMinutes >= GoalMinutes * 2;
        
        private double SessionsPerWeek { get; }
        private double AverageSessionDuration { get; }
        private ExerciseIntensity Intensity { get; }

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
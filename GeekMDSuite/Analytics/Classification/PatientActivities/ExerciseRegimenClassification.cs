using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public abstract class ExerciseRegimenClassification : IExerciseRegimenClassification, IClassifiable<GeekMDSuite.PatientActivities.ExerciseRegimenClassification>
    {
        protected ExerciseRegimenClassification (IExerciseRegimenParameters parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            SessionsPerWeek = parameters.SessionsPerWeek;
            AverageSessionDuration = parameters.AverageSessionDuration;
            Intensity = parameters.Intensity;
        }
        public abstract ExerciseDurationGoals Goals { get; }

        public virtual GeekMDSuite.PatientActivities.ExerciseRegimenClassification Classification
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Adequate 
                    : GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Insufficient;
            }
        }

        public override string ToString() => Classification.ToString();

        public virtual bool RegimenIsAdequate => DurationAndIntensityAreAdequate;
        
        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;

        public static double GoalMinutesHighIntensity => 
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity => 
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular).ModerateIntensity;
        
        public bool IntensityIsAdequate => IsHighIntensity || IsModerateIntensity;

        public bool DurationIsAdequate => IntensityIsAdequate && TimeGoalOrHigher;

        public double DurationPercentOfGoalAchieved =>
            GoalMinutes > 0 ? 100 * TotalMinutes / GoalMinutes : 0;
        
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
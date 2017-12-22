using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public abstract class ExerciseRegimenInterpretation : IExerciseRegimenClassification, IInterpretable<ExerciseRegimenClassification>
    {
        protected ExerciseRegimenInterpretation (IExerciseRegimenParameters parameters)
        {
            SessionsPerWeek = parameters.SessionsPerWeek;
            AverageSessionDuration = parameters.AverageSessionDuration;
            Intensity = parameters.Intensity;
        }
        public abstract InterpretationText Interpretation { get; }
        public abstract ExerciseDurationGoals Goals { get; }

        public virtual ExerciseRegimenClassification Classification
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? ExerciseRegimenClassification.Adequate : ExerciseRegimenClassification.Insufficient;
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
using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public abstract class
        ExerciseRegimenClassification : IClassifiable<ExericiseRegimen>
    {
        protected ExerciseRegimenClassification(ExerciseRegimen regimen)
        {
            if (regimen == null) throw new ArgumentNullException(nameof(regimen));
            SessionsPerWeek = regimen.SessionsPerWeek;
            AverageSessionDuration = regimen.AverageSessionDuration;
            Intensity = regimen.Intensity;
        }


        public virtual bool RegimenIsAdequate => DurationAndIntensityAreAdequate;

        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;

        public double DurationPercentOfGoalAchieved =>
            GoalMinutes > 0 ? 100 * TotalMinutes / GoalMinutes : 0;

        public bool IntensityIsAdequate => IsHighIntensity || IsModerateIntensity;

        public bool DurationIsAdequate => IntensityIsAdequate && TimeGoalOrHigher;

        public double SessionsPerWeek { get; }

        public double AverageSessionDuration { get; }

        public ExerciseIntensity Intensity { get; }

        public double GoalMinutes
        {
            get
            {
                if (IsHighIntensity) return Goals.HighIntensity;

                return IsModerateIntensity ? Goals.ModerateIntensity : 0;
            }
        }

        protected abstract ExerciseDurationGoals Goals { get; }

        protected static double GoalMinutesHighIntensity =>
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular)
                .HighIntensity;

        protected static double GoalMinutesModerateIntensity =>
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular)
                .ModerateIntensity;

        protected bool DurationAndIntensityAreAdequate => DurationIsAdequate && IntensityIsAdequate;

        protected bool TimeGoalOrHigher => TotalMinutes >= GoalMinutes;

        protected bool TimeAspirationalOrHigher => TotalMinutes >= GoalMinutes * 2;

        protected bool IsModerateIntensity => Intensity == ExerciseIntensity.Moderate;

        protected bool IsHighIntensity =>
            Intensity == ExerciseIntensity.High || Intensity == ExerciseIntensity.Vigorous;

        public virtual ExericiseRegimen Classification
        {
            get
            {
                if (RegimenIsAdequate && TimeAspirationalOrHigher)
                    return ExericiseRegimen.Aspirational;
                return RegimenIsAdequate
                    ? ExericiseRegimen.Adequate
                    : ExericiseRegimen.Insufficient;
            }
        }

        public override string ToString()
        {
            return Classification.ToString();
        }
    }
}
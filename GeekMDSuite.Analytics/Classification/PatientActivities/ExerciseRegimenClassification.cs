﻿using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public abstract class
        ExerciseRegimenClassification : IClassifiable<Core.Models.PatientActivities.ExerciseRegimenClassification>
    {
        protected ExerciseRegimenClassification(ExerciseRegimen regimen)
        {
            if (regimen == null) throw new ArgumentNullException(nameof(regimen));
            SessionsPerWeek = regimen.SessionsPerWeek;
            AverageSessionDuration = regimen.AverageSessionDuration;
            Intensity = regimen.Intensity;
        }

        public abstract ExerciseDurationGoals Goals { get; }

        public virtual bool RegimenIsAdequate => DurationAndIntensityAreAdequate;

        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;

        public static double GoalMinutesHighIntensity =>
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular)
                .HighIntensity;

        public static double GoalMinutesModerateIntensity =>
            ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular)
                .ModerateIntensity;

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

        private bool IsHighIntensity => Intensity == ExerciseIntensity.High || Intensity == ExerciseIntensity.Vigorous;

        private double GoalMinutes
        {
            get
            {
                if (IsHighIntensity) return Goals.HighIntensity;

                return IsModerateIntensity ? Goals.ModerateIntensity : 0;
            }
        }

        public virtual Core.Models.PatientActivities.ExerciseRegimenClassification Classification
        {
            get
            {
                if (RegimenIsAdequate && TimeAspirationalOrHigher)
                    return Core.Models.PatientActivities.ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate
                    ? Core.Models.PatientActivities.ExerciseRegimenClassification.Adequate
                    : Core.Models.PatientActivities.ExerciseRegimenClassification.Insufficient;
            }
        }

        public override string ToString()
        {
            return Classification.ToString();
        }
    }
}
using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Utilities.Generic;
using GeekMDSuite.Utilities.Helpers;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class ResistanceRegimenClassification : ExerciseRegimenClassification
    {
        private readonly ResistanceRegimen _regimen;

        public ResistanceRegimenClassification(ResistanceRegimen regimen) : base(regimen)
        {
            _regimen = regimen ?? throw new ArgumentNullException(nameof(regimen));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Resistance);
        }

        public sealed override bool RegimenIsAdequate => base.RegimenIsAdequate
                                                         && FeaturesOfRegimenAreIdeal
                                                         && RestIntervalGoalRange.ContainsOpen(_regimen
                                                             .SecondsRestDurationPerSet);

        public override ExericiseRegimen Classification
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

        public static Interval<int> RestIntervalGoalRange =>
            ExerciseRegimenGoalsRepository.GetResistanceRestIntervalGoals();
        
        protected sealed override ExerciseDurationGoals Goals { get; }

        private bool FeaturesOfRegimenAreIdeal
        {
            get
            {
                var presentFeatures = 0;

                if (_regimen.Features.Contains(ResistenceRegimenFeatures.LowerBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.UpperBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PullingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PushingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.RepetitionsToNearFailure)) presentFeatures++;

                return presentFeatures == EnumHelper<ResistenceRegimenFeatures>.CountElements;
            }
        }
    }
}
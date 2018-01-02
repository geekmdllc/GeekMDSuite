using System;
using GeekMDSuite.Core.Extensions;
using GeekMDSuite.Core.PatientActivities;
using GeekMDSuite.Core.Services.Repositories;
using GeekMDSuite.Core.Tools.Generic;

namespace GeekMDSuite.Core.Analytics.Classification.PatientActivities
{
    public class ResistanceRegimenClassification : ExerciseRegimenClassification
    {
        public ResistanceRegimenClassification(ResistanceRegimen regimen) : base(regimen)
        {
            _regimen = regimen ?? throw new ArgumentNullException(nameof(regimen));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Resistance);
        }
        
        
        public sealed override ExerciseDurationGoals Goals { get; }

        public sealed override bool RegimenIsAdequate => base.RegimenIsAdequate 
                                     && FeaturesOfRegimenAreIdeal                                                
                                     && RestIntervalGoalRange.ContainsOpen(_regimen.SecondsRestDurationPerSet);

        public override Core.PatientActivities.ExerciseRegimenClassification Classification
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return Core.PatientActivities.ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? Core.PatientActivities.ExerciseRegimenClassification.Adequate : Core.PatientActivities.ExerciseRegimenClassification.Insufficient;
            }
        }

        public static Interval<int> RestIntervalGoalRange  => ExerciseRegimenGoalsRepository.GetResistanceRestIntervalGoals();
        
        private readonly ResistanceRegimen _regimen;
        
        private bool FeaturesOfRegimenAreIdeal {
            get
            {
                var presentFeatures = 0;
                
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.LowerBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.UpperBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PullingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PushingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.RepetitionsToNearFailure)) presentFeatures++;
                
                return presentFeatures == EnumExtension<ResistenceRegimenFeatures>.Count;
            }
        }

    }
}
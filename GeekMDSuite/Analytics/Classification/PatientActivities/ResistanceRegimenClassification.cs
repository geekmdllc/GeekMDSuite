using System;
using GeekMDSuite.Extensions;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
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

        public override GeekMDSuite.PatientActivities.ExerciseRegimenClassification Classification
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Adequate : GeekMDSuite.PatientActivities.ExerciseRegimenClassification.Insufficient;
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
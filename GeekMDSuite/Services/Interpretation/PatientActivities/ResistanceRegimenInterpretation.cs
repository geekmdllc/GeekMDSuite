using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Fitness;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class ResistanceRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public ResistanceRegimenInterpretation(
            ResistanceRegimen regimen) 
            : base(regimen)
        {
            _regimen = regimen;
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Resistance);
        }
        
        public sealed override ExerciseDurationGoals Goals { get; }

        public sealed override bool RegimenIsAdequate => base.RegimenIsAdequate 
                                     && FeaturesOfRegimenAreIdeal                                                
                                     && RestIntervalGoalRange.ContainsOpen(_regimen.SecondsRestDurationPerSet);

        public override ExerciseRegimenClassification Classification
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? ExerciseRegimenClassification.Adequate : ExerciseRegimenClassification.Insufficient;
            }
        }

        public static Interval<int> RestIntervalGoalRange  => GetGoalValuesByExerciseType.ResistanceRestInterval();
        
        private readonly ResistanceRegimen _regimen;
        
        private bool FeaturesOfRegimenAreIdeal {
            get
            {
                //TODO: Ensure proper count and then consolidate this.
                var count = Enum.GetNames(typeof(ResistenceRegimenFeatures)).Length;
                Console.WriteLine(count);
                var presentFeatures = 0;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.LowerBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.UpperBodyTrained)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PullingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.PushingMovementsPerformed)) presentFeatures++;
                if (_regimen.Features.Contains(ResistenceRegimenFeatures.RepetitionsToNearFailure)) presentFeatures++;

                return presentFeatures == MaxPossibleFeatures;
            }
        }

        private const int MaxPossibleFeatures = 5;
    }
}
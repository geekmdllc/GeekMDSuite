using System.Collections.Generic;
using GeekMDSuite.Services.Exericse;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.PatientActivities
{
    public class ResistanceRegimen : ExerciseRegimen
    {
        public ResistanceRegimen(
            IExerciseRegimenParameters regimenParameters,
            int secondsRestDurationPerSet,
            List<ResistenceRegimenFeatures> regimenFeatures = null) 
            : base(regimenParameters)
        {
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Resistance);
            SecondsRestDurationPerSet = secondsRestDurationPerSet;
            Features = regimenFeatures ?? new List<ResistenceRegimenFeatures>();
        }
        
        public int SecondsRestDurationPerSet { get; }
        public List<ResistenceRegimenFeatures> Features { get; }
        public sealed override ExerciseDurationGoals Goals { get; }

        public sealed override bool RegimenIsAdequate => base.RegimenIsAdequate 
                                     && FeaturesOfRegimenAreIdeal                                                
                                     && RestIntervalGoalRange.ContainsOpen(SecondsRestDurationPerSet);

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
        
        private bool FeaturesOfRegimenAreIdeal => (int) FractionOfAdequateRegimen == 100;

        private double FractionOfAdequateRegimen
        {
            get
            {
                double presentFeatures = 0;
                if (Features.Contains(ResistenceRegimenFeatures.LowerBodyTrained)) presentFeatures += 1;
                if (Features.Contains(ResistenceRegimenFeatures.UpperBodyTrained)) presentFeatures += 1;
                if (Features.Contains(ResistenceRegimenFeatures.PullingMovementsPerformed)) presentFeatures += 1;
                if (Features.Contains(ResistenceRegimenFeatures.PushingMovementsPerformed)) presentFeatures += 1;
                if (Features.Contains(ResistenceRegimenFeatures.RepetitionsToNearFailure)) presentFeatures += 1;
            
                return 100 * presentFeatures / MaxPossibleFeatures;
            }
        }

        private const int MaxPossibleFeatures = 5;
    }
}
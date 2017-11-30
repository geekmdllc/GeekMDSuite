using System.Collections.Generic;

namespace GeekMDSuite
{
    public class ResistanceRegimen : ExerciseRegimenBase
    {
        private bool _regimenIsAdequate;

        public ResistanceRegimen(
            ExerciseRegimenBase baseRegimen,
            int secondsRestDurationPerSet,
            List<ResistenceRegimenFeatures> regimenFeatures = null) 
            : base(baseRegimen.SessionsPerWeek, baseRegimen.AverageSessionDuration, baseRegimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Resistance);
            SecondsRestDurationPerSet = secondsRestDurationPerSet;
            Features = regimenFeatures ?? new List<ResistenceRegimenFeatures>();
        }
        
        public int SecondsRestDurationPerSet { get; }
        public List<ResistenceRegimenFeatures> Features { get; }
        public sealed override ExerciseDurationGoals Goals { get; }

        public sealed override bool RegimenIsAdequate => base.RegimenIsAdequate 
                                     && FeaturesOfRegimenAreIdeal                                                
                                     && RestIntervalGoalRange.ContainsOpen(SecondsRestDurationPerSet);

        public ExerciseRegimenClassification Classify
        {
            get
            {
                if (  RegimenIsAdequate && TimeAspirationalOrHigher)
                    return ExerciseRegimenClassification.Aspirational;
                return RegimenIsAdequate ? ExerciseRegimenClassification.Adequate : ExerciseRegimenClassification.Insufficient;
            }
        }

        public static Interval<int> RestIntervalGoalRange  => GetExerciseGoalValues.ResistanceRestInterval();
        
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
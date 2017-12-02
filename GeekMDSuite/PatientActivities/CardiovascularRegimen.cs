using GeekMDSuite.Services.Fitness;

namespace GeekMDSuite.PatientActivities
{
    public class CardiovascularRegimen : ExerciseRegimen
    {
        public CardiovascularRegimen(IExerciseRegimenParameters regimenParameters) : base(regimenParameters)
        {
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular);
        }

        public sealed override ExerciseDurationGoals Goals { get; }
        
        public override ExerciseRegimenClassification Classification
        {
            get
            {
                if (DurationAndIntensityAreAdequate && TimeAspirationalOrHigher)
                    return ExerciseRegimenClassification.Aspirational;
                return DurationAndIntensityAreAdequate && TimeGoalOrHigher
                    ? ExerciseRegimenClassification.Adequate
                    : ExerciseRegimenClassification.Insufficient;
            }
        }
        
    }
}
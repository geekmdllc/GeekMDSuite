namespace GeekMDSuite
{
    public class CardiovascularRegimen : ExerciseRegimenBase
    {
        public CardiovascularRegimen(IExerciseRegimen regimen) 
            : base(regimen.SessionsPerWeek, regimen.AverageSessionDuration, regimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular);
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
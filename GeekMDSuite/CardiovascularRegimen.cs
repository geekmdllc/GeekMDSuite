namespace GeekMDSuite
{
    public class CardiovascularRegimen : ExerciseRegimenBase
    {
        public CardiovascularRegimen(ExerciseRegimenBase regimen) 
            : base(regimen.SessionsPerWeek, regimen.AverageSessionDuration, regimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular);
        }

        public sealed override ExerciseDurationGoals Goals { get; }
        
        public ExerciseRegimenClassification Classification
        {
            get
            {
                if (ExerciseRegimenHelper.DurationAndIntensityAreAdequate(this) 
                    && ExerciseRegimenHelper.TimeAspirationalOrHigher(this))
                    return ExerciseRegimenClassification.Aspirational;
                return ExerciseRegimenHelper.DurationAndIntensityAreAdequate(this) 
                       && ExerciseRegimenHelper.TimeGoalOrHigher(this)
                    ? ExerciseRegimenClassification.Adequate
                    : ExerciseRegimenClassification.Insufficient;
            }
        }
        
        public bool RegimenIsAdequate => 
            ExerciseRegimenHelper.DurationAndIntensityAreAdequate(this);

        public bool IntensityIsAdequate =>
            ExerciseRegimenHelper.IntensityIsAdequate(this);

        public bool DurationIsAdequate => 
            ExerciseRegimenHelper.DurationIsAdequate(this);

        public double DurationPercentOfGoalAchieved =>
            ExerciseRegimenHelper.DurationPercentOfGoalAchieved(this);
        
        public static double GoalMinutesHighIntensity => 
            GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity => 
            GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).ModerateIntensity;
    }
}
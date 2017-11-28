using GeekMDSuite.Services;

namespace GeekMDSuite.Models
{
    public class StretchingRegimen : ExerciseRegimenBase
    {
        public StretchingRegimen(ExerciseRegimenBase regimen) 
            : base(regimen.SessionsPerWeek, regimen.AverageSessionDuration, regimen.Intensity)
        {
            Goals = Services.GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Stretching);
        }
        public sealed override ExerciseDurationGoals Goals { get; set; }
    }
    
    
}
﻿namespace GeekMDSuite
{
    public class StretchingRegimen : ExerciseRegimenBase
    {
        public StretchingRegimen(ExerciseRegimenBase regimen) 
            : base(regimen.SessionsPerWeek, regimen.AverageSessionDuration, regimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Stretching);
        }
        public sealed override ExerciseDurationGoals Goals { get; }
    }
    
    
}
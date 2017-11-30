namespace GeekMDSuite
{
    public static class StretchingRegimenInterpretation
    {
        public static ExerciseRegimenClassification Interpret(StretchingRegimen regimen)
        {
            if (ExerciseRegimenHelper.DurationAndIntensityAreAdequate(regimen) 
                && ExerciseRegimenHelper.TimeAspirationalOrHigher(regimen))
                return ExerciseRegimenClassification.Aspirational;
            return ExerciseRegimenHelper.DurationAndIntensityAreAdequate(regimen) 
                   && ExerciseRegimenHelper.TimeGoalOrHigher(regimen)
                ? ExerciseRegimenClassification.Adequate
                : ExerciseRegimenClassification.Insufficient;
        }
        public static double GoalMinutesHighIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).ModerateIntensity;
        
        public static bool RegimenIsAdequate(StretchingRegimen regimen) => ExerciseRegimenHelper.DurationAndIntensityAreAdequate(regimen);

        public static bool IntensityIsAdequate(StretchingRegimen regimen) =>
            ExerciseRegimenHelper.IntensityIsAdequate(regimen);

        public static bool DurationIsAdequate(StretchingRegimen regimen) => 
            ExerciseRegimenHelper.DurationIsAdequate(regimen);

        public static double DurationPercentOfGoalAchieved(StretchingRegimen regimen) =>
            ExerciseRegimenHelper.DurationPercentOfGoalAchieved(regimen);
    }
}
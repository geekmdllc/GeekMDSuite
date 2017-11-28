using GeekMDSuite.Models;
using GeekMDSuite.Services;

namespace GeekMDSuite
{
    public static class StretchingRegimenInterpretation
    {
        public static ExerciseRegimenClassification Interpret(StretchingRegimen regimen)
        {
            if (ExerciseRegimenInterpretation.DurationAndIntensityAreAdequate(regimen) 
                && ExerciseRegimenInterpretation.TimeAspirationalOrHigher(regimen))
                return ExerciseRegimenClassification.Aspirational;
            return ExerciseRegimenInterpretation.DurationAndIntensityAreAdequate(regimen) 
                   && ExerciseRegimenInterpretation.TimeGoalOrHigher(regimen)
                ? ExerciseRegimenClassification.Adequate
                : ExerciseRegimenClassification.Insufficient;
        }
        public static double GoalMinutesHighIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).HighIntensity;

        public static double GoalMinutesModerateIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Cardiovascular).ModerateIntensity;
        
        public static bool RegimenIsAdequate(StretchingRegimen regimen) => ExerciseRegimenInterpretation.DurationAndIntensityAreAdequate(regimen);

        public static bool IntensityIsAdequate(StretchingRegimen regimen) =>
            ExerciseRegimenInterpretation.IntensityIsAdequate(regimen);

        public static bool DurationIsAdequate(StretchingRegimen regimen) => 
            ExerciseRegimenInterpretation.DurationIsAdequate(regimen);

        public static double DurationPercentOfGoalAchieved(StretchingRegimen regimen) =>
            ExerciseRegimenInterpretation.DurationPercentOfGoalAchieved(regimen);
    }
}
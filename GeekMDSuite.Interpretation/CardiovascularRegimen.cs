using GeekMDSuite.Common.Models;
using GeekMDSuite.Common.Services;

namespace GeekMDSuite.Interpretation
{
    public static class CardiovascularRegimenInterpretation
    {
        public static ExerciseRegimenClassification Interpret(CardiovascularRegimen regimen)
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
        
        public static bool RegimenIsAdequate(CardiovascularRegimen regimen) => ExerciseRegimenInterpretation.DurationAndIntensityAreAdequate(regimen);

        public static bool IntensityIsAdequate(CardiovascularRegimen regimen) =>
            ExerciseRegimenInterpretation.IntensityIsAdequate(regimen);

        public static bool DurationIsAdequate(CardiovascularRegimen regimen) => 
            ExerciseRegimenInterpretation.DurationIsAdequate(regimen);

        public static double DurationPercentOfGoalAchieved(CardiovascularRegimen regimen) =>
            ExerciseRegimenInterpretation.DurationPercentOfGoalAchieved(regimen);
    }
}
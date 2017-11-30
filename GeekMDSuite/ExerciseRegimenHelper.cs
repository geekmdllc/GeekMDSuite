namespace GeekMDSuite
{
    // To avoid confusion, this class was made internal. Classes 
    // requiring exposing these helper methods to library users can wrap them.
    internal static class ExerciseRegimenHelper
    {
        internal static bool IntensityIsAdequate(ExerciseRegimenBase regimen) => IsHighIntensity(regimen) || IsModerateIntensity(regimen);

        internal static bool DurationIsAdequate(ExerciseRegimenBase regimen) => IntensityIsAdequate(regimen) && TimeGoalOrHigher(regimen);

        internal static bool DurationAndIntensityAreAdequate(ExerciseRegimenBase regimen) => DurationIsAdequate(regimen) && IntensityIsAdequate(regimen);

        internal static double DurationPercentOfGoalAchieved(ExerciseRegimenBase regimen)
        {
            return GoalMinutes(regimen) >= 0 ? 100 * regimen.TotalMinutes / GoalMinutes(regimen) : 0;
        }
        private static bool IsModerateIntensity(IExerciseRegimen regimen) => regimen.Intensity == ExerciseIntensity.Moderate;

        private static bool IsHighIntensity(IExerciseRegimen regimen)
        {
            return (regimen.Intensity == ExerciseIntensity.High || regimen.Intensity == ExerciseIntensity.Vigorous);
        }
        internal static bool TimeGoalOrHigher(ExerciseRegimenBase regimen, bool compareToAspirational = false)
        {
            return regimen.TotalMinutes >= GoalMinutes(regimen) * (compareToAspirational ? 2 : 1);
        }
        internal static bool TimeAspirationalOrHigher(ExerciseRegimenBase regimen) => TimeGoalOrHigher(regimen, true);

        private static double GoalMinutes(ExerciseRegimenBase regimen)
        {
            if (IsHighIntensity(regimen)) return regimen.Goals.HighIntensity;
            
            return IsModerateIntensity(regimen) ? regimen.Goals.ModerateIntensity : 0;
        }
    }
}
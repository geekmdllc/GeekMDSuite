using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation
{
    public static class ExerciseRegimenInterpretation
    {
        public static bool IntensityIsAdequate(ExerciseRegimenBase regimen) => IsHighIntensity(regimen) || IsModerateIntensity(regimen);

        public static bool DurationIsAdequate(ExerciseRegimenBase regimen) => IntensityIsAdequate(regimen) && TimeGreaterOrEqualToGoal(regimen);

        public static bool RegimenIsAdequate(ExerciseRegimenBase regimen) => DurationIsAdequate(regimen) && IntensityIsAdequate(regimen);

        public static double RegimenPercentOfGoalAchieved(ExerciseRegimenBase regimen)
        {
            return GoalMinutes(regimen) >= 0 ? 100 * regimen.TotalMinutes / GoalMinutes(regimen) : 0;
        }
        public static bool IsModerateIntensity(ExerciseRegimenBase regimen) => regimen.Intensity == ExerciseIntensity.Moderate;
        
        public static bool IsHighIntensity(ExerciseRegimenBase regimen)
        {
            return (regimen.Intensity == ExerciseIntensity.High || regimen.Intensity == ExerciseIntensity.Vigorous);
        }

        public static bool TimeGreaterOrEqualToGoal(ExerciseRegimenBase regimen, bool compareToAspirational = false)
        {
            return regimen.TotalMinutes >= GoalMinutes(regimen) * (compareToAspirational ? 2 : 1);
        }

        public static bool TimeGreaterOrEqualToAspirationalGoal(ExerciseRegimenBase regimen) => TimeGreaterOrEqualToGoal(regimen, true);

        public static double GoalMinutes(ExerciseRegimenBase regimen)
        {
            if (IsHighIntensity(regimen)) return regimen.Goals.HighIntensity;
            
            return IsModerateIntensity(regimen) ? regimen.Goals.ModerateIntensity : 0;
        }
    }
}
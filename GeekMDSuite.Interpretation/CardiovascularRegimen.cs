using System;
using GeekMDSuite.Common;

namespace GeekMDSuite.Interpretation
{
    public static class CardiovascularRegimenInterpretation
    {
        public static ExerciseRegimenClassification Calculate(CardiovascularRegimen regimen)
        {
            if (RegimenIsAdequate(regimen) && CardioTimeExceedsComparable(regimen.TotalMinutes,GoalMinutes(regimen) * 2))
                return ExerciseRegimenClassification.Aspirational;
            return RegimenIsAdequate(regimen) && CardioTimeExceedsComparable(regimen.TotalMinutes,GoalMinutes(regimen))
                ? ExerciseRegimenClassification.Adequate
                : ExerciseRegimenClassification.Insufficient;
        }

        public static bool IntensityIsAdequate(CardiovascularRegimen regimen) => IsHighIntensity(regimen) || IsModerateIntensity(regimen);

        public static bool DurationIsAdequate(CardiovascularRegimen regimen)
        {
            return IntensityIsAdequate(regimen) && CardioTimeExceedsComparable(regimen.TotalMinutes,GoalMinutes(regimen));
        }
        
        public static bool RegimenIsAdequate(CardiovascularRegimen regimen)
        {
            return DurationIsAdequate(regimen) && IntensityIsAdequate(regimen);
        }

        public static double RegimenPercentOfGoalAchieved(CardiovascularRegimen regimen)
        {
            return GoalMinutes(regimen) >= 0 ? regimen.TotalMinutes / GoalMinutes(regimen) : 0;
        }
        private static bool IsModerateIntensity(CardiovascularRegimen regimen) => regimen.Intensity == ExerciseIntensity.Moderate;
        
        private static bool IsHighIntensity(CardiovascularRegimen regimen)
        {
            return (regimen.Intensity == ExerciseIntensity.High || regimen.Intensity == ExerciseIntensity.Vigorous);
        }
        
        private static bool CardioTimeExceedsComparable(double regimen, double comparable) => regimen > comparable;
        
        private static double GoalMinutes(CardiovascularRegimen regimen)
        {
            if (IsHighIntensity(regimen))
                return GoalMinutesHighIntensity;
            return IsModerateIntensity(regimen) ? GoalMinutesModerateIntensity : 0;
        }
        public static double GoalMinutesHighIntensity = 75;
        public static double GoalMinutesModerateIntensity = 150;
    }
}
using System;
using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation
{
    public static class CardiovascularRegimenInterpretation
    {
        public static ExerciseRegimenClassification Calculate(CardiovascularRegimen regimen)
        {
            if (ExerciseRegimenInterpretation.RegimenIsAdequate(regimen) && ExerciseRegimenInterpretation.TimeGreaterOrEqualToAspirationalGoal(regimen))
                return ExerciseRegimenClassification.Aspirational;
            return ExerciseRegimenInterpretation.RegimenIsAdequate(regimen) && ExerciseRegimenInterpretation.TimeGreaterOrEqualToGoal(regimen)
                ? ExerciseRegimenClassification.Adequate
                : ExerciseRegimenClassification.Insufficient;
        }

        public static double GoalMinutesHighIntensity = 75;
        public static double GoalMinutesModerateIntensity = 150;
    }
}
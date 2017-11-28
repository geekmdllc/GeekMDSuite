using System.Globalization;
using GeekMDSuite.Models;
using GeekMDSuite.Services;
using GeekMDSuite.Tools;

namespace GeekMDSuite
{
    public static class ResistanceRegimenInterpretation
    {
        public static ExerciseRegimenClassification Interpret(ResistanceRegimen regimen)
        {
            if (ExerciseRegimenInterpretation.TimeAspirationalOrHigher(regimen) && RegimenIsAdequate(regimen))
                return ExerciseRegimenClassification.Aspirational;
            return RegimenIsAdequate(regimen) ? ExerciseRegimenClassification.Adequate : ExerciseRegimenClassification.Insufficient;
        }
        
        public static double GoalMinutesHighIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Resistance).HighIntensity;
        
        public static double GoalMinutesModerateIntensity = GetExerciseGoalValues
            .TotalWeeklyDuration(ExerciseClassifications.Resistance).ModerateIntensity;
        
        public static readonly Interval<int> GoalRestInterval = GetExerciseGoalValues.ResistanceRestInterval();
        
        public static bool RegimenIsAdequate(ResistanceRegimen regimen)
        {
            return ExerciseRegimenInterpretation.DurationAndIntensityAreAdequate(regimen)
                   && FeaturesOfRegimenAreIdeal(regimen)
                   && GoalRestInterval.ContainsClosed(regimen.SecondsRestDurationPerSet);
        }
        private static bool FeaturesOfRegimenAreIdeal(ResistanceRegimen regimen)
        {
            return (int) FractionOfAdequateRegimen(regimen) == 100;
        }

        private static double FractionOfAdequateRegimen(ResistanceRegimen regimen)
        {
            double presentFeatures = 0;
            if (regimen.Features.Contains(ResistenceRegimenFeatures.LowerBodyTrained)) presentFeatures += 1;
            if (regimen.Features.Contains(ResistenceRegimenFeatures.UpperBodyTrained)) presentFeatures += 1;
            if (regimen.Features.Contains(ResistenceRegimenFeatures.PullingMovementsPerformed)) presentFeatures += 1;
            if (regimen.Features.Contains(ResistenceRegimenFeatures.PushingMovementsPerformed)) presentFeatures += 1;
            if (regimen.Features.Contains(ResistenceRegimenFeatures.RepetitionsToNearFailure)) presentFeatures += 1;
            
            return 100 * presentFeatures / MaxPossibleFeatures;
        }

        public static bool IntensityIsAdequate(ResistanceRegimen regimen) =>
            ExerciseRegimenInterpretation.IntensityIsAdequate(regimen);

        public static bool DurationIsAdequate(ResistanceRegimen regimen) => 
            ExerciseRegimenInterpretation.DurationIsAdequate(regimen);

        public static double DurationPercentOfGoalAchieved(ResistanceRegimen regimen) =>
            ExerciseRegimenInterpretation.DurationPercentOfGoalAchieved(regimen);

        private const int MaxPossibleFeatures = 5;
    }
}
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Tools.Generic;

namespace GeekMDSuite.Analytics.Repositories
{
    internal static class ExerciseRegimenGoalsRepository
    {
        internal static ExerciseDurationGoals GetTotalWeeklyDurationGoals(ExerciseClassification exercise)
        {
            if (exercise == ExerciseClassification.Cardiovascular)
                return new ExerciseDurationGoals(150, 75);
            return exercise == ExerciseClassification.Resistance
                ? new ExerciseDurationGoals(120, 90)
                : new ExerciseDurationGoals(30, 20);
        }

        internal static Interval<int> GetResistanceRestIntervalGoals(int upper = 120, int lower = 30)
        {
            return new Interval<int>(lower, upper);
        }
    }
}
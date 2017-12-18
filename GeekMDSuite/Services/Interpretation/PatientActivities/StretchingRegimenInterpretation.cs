using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class StretchingRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public StretchingRegimenInterpretation(IExerciseRegimenParameters parameters) : base(parameters)
        {
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Stretching);
        }

        public override ExerciseDurationGoals Goals { get; }
        public override InterpretationText Interpretation => throw new NotImplementedException();
    }
}
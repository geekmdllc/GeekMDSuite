using System;

namespace GeekMDSuite
{
    public class StretchingRegimen : ExerciseRegimenBase, IInterpretable
    {

        public StretchingRegimen(IExerciseRegimen regimen) 
            : base(regimen.SessionsPerWeek, regimen.AverageSessionDuration, regimen.Intensity)
        {
            Goals = GetExerciseGoalValues.TotalWeeklyDuration(ExerciseClassifications.Stretching);
        }
        public sealed override ExerciseDurationGoals Goals { get; }
        
        public override ExerciseRegimenClassification Classification
        {
            get
            {
                if (DurationAndIntensityAreAdequate && TimeAspirationalOrHigher)
                    return ExerciseRegimenClassification.Aspirational;
                return DurationAndIntensityAreAdequate  && TimeGoalOrHigher
                    ? ExerciseRegimenClassification.Adequate
                    : ExerciseRegimenClassification.Insufficient;
            }
        }

        public Interpretation Interpretation => throw new NotImplementedException();
    }
    
    
}
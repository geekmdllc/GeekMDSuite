using System;
using GeekMDSuite.Services.Fitness;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools;

namespace GeekMDSuite.PatientActivities
{
    public class StretchingRegimen : ExerciseRegimen, IInterpretable
    {

        public StretchingRegimen(IExerciseRegimenParameters regimenParameters) 
            : base(regimenParameters)
        {
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassifications.Stretching);
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

        public InterpretationText Interpretation => throw new NotImplementedException();
    }
    
    
}
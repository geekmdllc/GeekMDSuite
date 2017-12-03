using GeekMDSuite.PatientActivities;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class StretchingRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public StretchingRegimenInterpretation(IExerciseRegimenParameters parameters) : base(parameters)
        {
        }
    }

    public class StretchingRegimen : ExerciseRegimen
    {
        public StretchingRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity) 
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
        }
    }
    
}
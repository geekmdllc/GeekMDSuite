namespace GeekMDSuite.PatientActivities
{
    public interface IExerciseRegimenParameters
    {
        double SessionsPerWeek { get; }
        double AverageSessionDuration { get; }
        ExerciseIntensity Intensity { get; }
    }
}
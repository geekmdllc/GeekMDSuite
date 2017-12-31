namespace GeekMDSuite.PatientActivities
{
    public interface IExerciseRegimenParameters
    {
        double SessionsPerWeek { get; set; }
        double AverageSessionDuration { get; set; }
        ExerciseIntensity Intensity { get; set; }
    }
}
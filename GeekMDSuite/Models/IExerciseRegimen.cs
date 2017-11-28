namespace GeekMDSuite.Models
{
    public interface IExerciseRegimen
    {
        double SessionsPerWeek { get; set; }
        double AverageSessionDuration { get; set; }
        ExerciseIntensity Intensity { get; set; }
    }
}
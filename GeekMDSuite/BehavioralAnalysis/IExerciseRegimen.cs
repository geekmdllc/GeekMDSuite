namespace GeekMDSuite.BehavioralAnalysis
{
    public interface IExerciseRegimen
    {
        double SessionsPerWeek { get; set; }
        double AverageSessionDuration { get; set; }
        ExerciseIntensity Intensity { get; set; }
        ExerciseRegimenClassification Classification { get; }
    }
}
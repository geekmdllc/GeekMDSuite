namespace GeekMDSuite.PatientActivities
{
    public interface IExerciseRegimen : IExerciseRegimenParameters
    {
        ExerciseRegimenClassification Classification { get; }
    }
}
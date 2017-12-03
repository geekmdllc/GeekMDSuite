namespace GeekMDSuite.PatientActivities
{
    public class CardiovascularRegimen : ExerciseRegimen
    {
        public CardiovascularRegimen(IExerciseRegimenParameters parameters) 
            : base(parameters.SessionsPerWeek, 
                parameters.AverageSessionDuration, 
                parameters.Intensity) { }
    }
}
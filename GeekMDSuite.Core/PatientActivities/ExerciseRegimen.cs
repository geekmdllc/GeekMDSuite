namespace GeekMDSuite.Core.PatientActivities
{
    public abstract class ExerciseRegimen : IExerciseRegimenParameters
    {
        protected ExerciseRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }

        protected ExerciseRegimen()
        {
            
        }

        public double SessionsPerWeek { get; set; }

        public double AverageSessionDuration { get; set; }

        public ExerciseIntensity Intensity { get; set; }
        
        public override string ToString() => 
            $"{SessionsPerWeek * AverageSessionDuration} minutes per week at {Intensity} intensity.";
    }
}
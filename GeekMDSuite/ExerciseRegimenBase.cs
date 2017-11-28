using System;

namespace GeekMDSuite
{
    public class ExerciseRegimenBase : IExerciseRegimen
    {
        public ExerciseRegimenBase (double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public virtual ExerciseDurationGoals Goals
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;
    }
}
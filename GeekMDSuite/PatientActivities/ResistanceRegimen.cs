using System.Collections.Generic;

namespace GeekMDSuite.PatientActivities
{
    public class ResistanceRegimen : ExerciseRegimen
    {
        internal ResistanceRegimen(
            IExerciseRegimenParameters regimen, 
            int secondsRestDurationPerSet, 
            List<ResistenceRegimenFeatures> features) 
            : base(regimen.SessionsPerWeek, 
                regimen.AverageSessionDuration, 
                regimen.Intensity)
        {
            SecondsRestDurationPerSet = secondsRestDurationPerSet;
            Features = features;
        }
        public int SecondsRestDurationPerSet { get; }
        public List<ResistenceRegimenFeatures> Features { get; }
    }

    public class ResistanceRegimenBuilder
    {
        private double _sessionsPerWeek;
        private double _averageSessionDuration;
        private ExerciseIntensity _intensity;
        private int _secondsRestDurationPerSet;
        private readonly List<ResistenceRegimenFeatures> _features = new List<ResistenceRegimenFeatures>();

        public ResistanceRegimenBuilder SetSessionsPerWeek(double sessionsPerWeek)
        {
            _sessionsPerWeek = sessionsPerWeek;
            return this;
        }

        public ResistanceRegimenBuilder SetAverageSessionDuration(double averageSessionDuration)
        {
            _averageSessionDuration = averageSessionDuration;
            return this;
        }

        public ResistanceRegimenBuilder SetIntensity(ExerciseIntensity intensity)
        {
            _intensity = intensity;
            return this;
        }
        
        public ResistanceRegimenBuilder SetSecondsRestDurationPerSet(int seconds)
        {
            _secondsRestDurationPerSet = seconds;
            return this;
        }
        
        public ResistanceRegimenBuilder AddRegimenFeature(ResistenceRegimenFeatures feature)
        {
            _features.Add(feature);
            return this;
        }

        public ResistanceRegimen Build() => new ResistanceRegimen(
            ExerciseRegimenParameters.Build(_sessionsPerWeek, _averageSessionDuration, _intensity),
            _secondsRestDurationPerSet, _features);
    }
}
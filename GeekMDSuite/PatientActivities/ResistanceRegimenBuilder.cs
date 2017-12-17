using System.Collections.Generic;

namespace GeekMDSuite.PatientActivities
{
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
        
        public ResistanceRegimenBuilder ConfirmLowerBodyTrained()
        {
            _features.Add(ResistenceRegimenFeatures.LowerBodyTrained);
            return this;
        }
        
        public ResistanceRegimenBuilder ConfirmPullingMovementsPerformed()
        {
            _features.Add(ResistenceRegimenFeatures.PullingMovementsPerformed);
            return this;
        }
        public ResistanceRegimenBuilder ConfirmPushingMovementsPerformed()
        {
            _features.Add(ResistenceRegimenFeatures.PushingMovementsPerformed);
            return this;
        }
        public ResistanceRegimenBuilder ConfirmRepetitionsToNearFailure()
        {
            _features.Add(ResistenceRegimenFeatures.RepetitionsToNearFailure);
            return this;
        }
        public ResistanceRegimenBuilder ConfirmUpperBodyTrained()
        {
            _features.Add(ResistenceRegimenFeatures.UpperBodyTrained);
            return this;
        }

        public ResistanceRegimen Build() => new ResistanceRegimen(
            ExerciseRegimenParameters.Build(_sessionsPerWeek, _averageSessionDuration, _intensity),
            _secondsRestDurationPerSet, _features);
        
        
    }
}
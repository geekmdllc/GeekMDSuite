using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.Core.Builders.PatientActivities
{
    public class ResistanceRegimenBuilder : Builder<ResistanceRegimenBuilder, ResistanceRegimen>
    {
        private readonly List<ResistenceRegimenFeatures> _features = new List<ResistenceRegimenFeatures>();
        private double _averageSessionDuration;
        private ExerciseIntensity _intensity;
        private bool _intensityIsSet;
        private int _secondsRestDurationPerSet;

        private double _sessionsPerWeek;

        public override ResistanceRegimen Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public override ResistanceRegimen BuildWithoutModelValidation()
        {
            return new ResistanceRegimen
            {
                SecondsRestDurationPerSet = _secondsRestDurationPerSet,
                AverageSessionDuration = _averageSessionDuration,
                Features = _features,
                Intensity = _intensity,
                SessionsPerWeek = _sessionsPerWeek
            };
        }

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
            _intensityIsSet = true;
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

        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (IsEffectivelyZero(_sessionsPerWeek)) message += $"{nameof(SetSessionsPerWeek)} ";
            if (IsEffectivelyZero(_averageSessionDuration)) message += $"{nameof(SetAverageSessionDuration)} ";
            if (!_intensityIsSet) message += $"{nameof(SetSessionsPerWeek)} ";
            if (IsEffectivelyZero(_secondsRestDurationPerSet)) message += $"{nameof(SetSecondsRestDurationPerSet)} ";

            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " must be set");
        }

        private static bool IsEffectivelyZero(double value)
        {
            return Math.Abs(value - default(double)) < 0.001;
        }
    }
}
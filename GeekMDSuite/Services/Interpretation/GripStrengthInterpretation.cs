using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public class GripStrengthInterpretation : IInterpretable<GripStrengthClassification>
    {

        public GripStrengthInterpretation(GripStrength gripStrength, IPatient patient)
        {
            _patient = patient;
            _gripStrength = gripStrength;
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public GripStrengthClassification Classification => throw new NotImplementedException();
        
        private readonly GripStrength _gripStrength;
        private readonly IPatient _patient;
        private double _lowerLimitOfNormal;
        private double _upperLimitOfNormal;

        private void SetLimitsInKilograms(double lower, double upper)
        {
            _lowerLimitOfNormal = lower;
            _upperLimitOfNormal = upper;
        }
        private void GetLimitsInKilograms()
        {
            if (Gender.IsGenotypeXy(_patient.Gender))
                GetMaleLimits();
            else
                GetFemaleLimits();
        }

        private GripStrengthClassification Classify()
        {
            return _gripStrength.Left.Kilograms < _gripStrength.Right.Kilograms 
                ? ClassifySide(_gripStrength.Left) 
                : ClassifySide(_gripStrength.Right);
        }
        
        private GripStrengthClassification ClassifySide(IMassMeasurement gripStrength)
        {
            if(gripStrength.Kilograms < _lowerLimitOfNormal) 
                return GripStrengthClassification.Weak;
            if (gripStrength.Kilograms >= _lowerLimitOfNormal &&
                gripStrength.Kilograms <= _upperLimitOfNormal) 
                return GripStrengthClassification.Normal;
            return gripStrength.Kilograms > _upperLimitOfNormal 
                ? GripStrengthClassification.Strong 
                : throw new ArgumentOutOfRangeException(nameof(gripStrength));
        }

        private void GetFemaleLimits()
        {
            if (_patient.Age >= 10 && _patient.Age <= 11)
                SetLimitsInKilograms(11.8, 21.6);
            else if (_patient.Age >= 12 && _patient.Age <= 13)
                SetLimitsInKilograms(14.6, 24.4);
            else if (_patient.Age >= 14 && _patient.Age <= 15)
                SetLimitsInKilograms(15.5, 27.3);
            else if (_patient.Age >= 16 && _patient.Age <= 17)
                SetLimitsInKilograms(17.2, 29.0);
            else if (_patient.Age >= 18 && _patient.Age <= 19)
                SetLimitsInKilograms(19.2, 31.0);
            else if (_patient.Age >= 20 && _patient.Age <= 24)
                SetLimitsInKilograms(21.5, 35.3);
            else if (_patient.Age >= 25 && _patient.Age <= 29)
                SetLimitsInKilograms(25.6, 41.4);
            else if (_patient.Age >= 30 && _patient.Age <= 34)
                SetLimitsInKilograms(21.5, 35.3);
            else if (_patient.Age >= 35 && _patient.Age <= 39)
                SetLimitsInKilograms(20.3, 34.1);
            else if (_patient.Age >= 40 && _patient.Age <= 44)
                SetLimitsInKilograms(18.9, 32.7);
            else if (_patient.Age >= 45 && _patient.Age <= 49)
                SetLimitsInKilograms(18.6, 32.4);
            else if (_patient.Age >= 50 && _patient.Age <= 54)
                SetLimitsInKilograms(18.1, 31.9);
            else if (_patient.Age >= 55 && _patient.Age <= 59)
                SetLimitsInKilograms(17.7, 31.5);
            else if (_patient.Age >= 60 && _patient.Age <= 64)
                SetLimitsInKilograms(17.2, 31.0);
            else if (_patient.Age >= 65 && _patient.Age <= 69)
                SetLimitsInKilograms(15.4, 24.5);
            else
                SetLimitsInKilograms(14.7, 24.5);
        }

        private void GetMaleLimits()
        {
            if (_patient.Age >= 10 && _patient.Age <= 11)
                SetLimitsInKilograms(12.6, 22.4);
            else if (_patient.Age >= 12 && _patient.Age <= 13)
                SetLimitsInKilograms(19.4, 31.2);
            else if (_patient.Age >= 14 && _patient.Age <= 15)
                SetLimitsInKilograms(28.5, 44.3);
            else if (_patient.Age >= 16 && _patient.Age <= 17)
                SetLimitsInKilograms(32.6, 52.4);
            else if (_patient.Age >= 18 && _patient.Age <= 19)
                SetLimitsInKilograms(35.7, 55.5);
            else if (_patient.Age >= 20 && _patient.Age <= 24)
                SetLimitsInKilograms(36.8, 56.6);
            else if (_patient.Age >= 25 && _patient.Age <= 29)
                SetLimitsInKilograms(37.7, 57.5);
            else if (_patient.Age >= 30 && _patient.Age <= 34)
                SetLimitsInKilograms(36.0, 55.8);
            else if (_patient.Age >= 35 && _patient.Age <= 39)
                SetLimitsInKilograms(35.8, 55.6);
            else if (_patient.Age >= 40 && _patient.Age <= 44)
                SetLimitsInKilograms(35.5, 55.3);
            else if (_patient.Age >= 45 && _patient.Age <= 49)
                SetLimitsInKilograms(34.7, 54.5);
            else if (_patient.Age >= 50 && _patient.Age <= 54)
                SetLimitsInKilograms(32.9, 50.7);
            else if (_patient.Age >= 55 && _patient.Age <= 59)
                SetLimitsInKilograms(30.7, 48.5);
            else if (_patient.Age >= 60 && _patient.Age <= 64)
                SetLimitsInKilograms(30.2, 48.0);
            else if (_patient.Age >= 65 && _patient.Age <= 69)
                SetLimitsInKilograms(28.2, 44.0);
            else
                SetLimitsInKilograms(21.3, 35.1);
        }
    }
}
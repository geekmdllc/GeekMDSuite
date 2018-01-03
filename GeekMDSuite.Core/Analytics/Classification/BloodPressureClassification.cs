using System;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BloodPressureClassificationResult
    {
        public BloodPressureStage Stage { get; set; }
    }
    
    public class BloodPressureClassification : IClassifiable<BloodPressureClassificationResult>
    {
        public BloodPressureClassification(IBloodPressure parameters) : this()
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public BloodPressureClassificationResult Classification => new BloodPressureClassificationResult()
        {
            Stage = Classify()
        };

        public override string ToString() => Classification.ToString();
        
        private readonly IBloodPressure _parameters;

        public BloodPressureClassification()
        {
            
        }

        public static class LowerLimits
        {
            public static class Diastolic
            {
                public const int Normal = 60;
                public const int Stage1Hypertension = 80;
                public const int Stage2Hypertension = 90;
                public const int HypertensiveUrgency = 120;
            }

            public static class Systolic
            {
                public const int Normal = 100;
                public const int Elevated = 120;
                public const int Stage1Hypertension = 130;
                public const int Stage2Hypertension = 140;
                public const int HypertensiveUrgency = 180;
            }
        }
        
        private BloodPressureStage Classify()
        {
            if (IsLow) return BloodPressureStage.Low;
            if (IsNormal) return BloodPressureStage.Normal;
            if (IsElevated) return BloodPressureStage.Elevated;
            if (IsStage1Htn) return BloodPressureStage.Stage1Hypertension;
            if (IsStage2Htn) return BloodPressureStage.Stage2Hypertension;
            return IsUrgency ? BloodPressureStage.HypertensiveUrgency : BloodPressureStage.HypertensiveEmergency;
        }

        private bool IsLow => _parameters.Systolic < LowerLimits.Systolic.Normal && _parameters.Diastolic < LowerLimits.Diastolic.Normal;

        private bool IsNormal => !IsLow && _parameters.Systolic < LowerLimits.Systolic.Elevated &&
                                 _parameters.Diastolic < LowerLimits.Diastolic.Stage1Hypertension;

        private bool IsElevated => !IsNormal && _parameters.Systolic < LowerLimits.Systolic.Stage1Hypertension &&
                                   _parameters.Diastolic < LowerLimits.Diastolic.Stage1Hypertension;

        private bool IsStage1Htn => !IsElevated && _parameters.Systolic < LowerLimits.Systolic.Stage2Hypertension &&
                                    _parameters.Diastolic < LowerLimits.Diastolic.Stage2Hypertension;

        private bool IsStage2Htn => !IsStage1Htn && _parameters.Systolic < LowerLimits.Systolic.HypertensiveUrgency &&
                                    _parameters.Diastolic < LowerLimits.Diastolic.HypertensiveUrgency;

        private bool IsUrgency => !IsStage2Htn && !_parameters.OrganDamage;
                
       
        
    }
}
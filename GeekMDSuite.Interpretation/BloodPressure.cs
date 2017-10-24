using System.Collections;
using System.Collections.Generic;
using GeekMDSuite.Contracts;

namespace GeekMDSuite.Interpretation
{
    public static class BloodPressure
    {
        // API user likely to need access to these values
        public static readonly int SystolicLowerLimitOfNormal = 100;

        public static readonly int SystolicLowerLimitOfPrehypertension = 120;
        public static readonly int SystolicLowerLimitOfStageIHypertension = 140;
        public static readonly int SystolicLowerLimitOfStageIIHypertension = 160;
        public static readonly int SystolicLowerLimitofHypertensiveUrgency = 180;
        public static readonly int DiastolicLowerLimitOfNormal = 60;
        public static readonly int DiastolicLowerLimitOfPrehypertension = 80;
        public static readonly int DiastolicLowerLimitOfStageIHypertension = 90;
        public static readonly int DiastolicLowerLimitOfStageIIHypertension = 100;
        public static readonly int DiastolicLowerLimitOfHypertensiveUrgency = 120;

        public static BloodPressureStages Interpret(int systolicBp, int diastolicBp, bool endOrganDamagePresent)
        {

            var map = GenerateBloodPressureStagesMap();
           
            return GetBloodPressureStage(systolicBp, diastolicBp, endOrganDamagePresent, map);
            
        }

        private static BloodPressureStages GetBloodPressureStage(int systolicBp, int diastolicBp, bool endOrganDamage, List<BloodPressureStage> map)
        {
            var stage = BloodPressureStages.Normotension;

            foreach (var entry in map)
            {
                if (entry.IsInStage(systolicBp, diastolicBp, endOrganDamage)) stage = entry.Stage;
            }
            return stage;
        }

        private static List<BloodPressureStage> GenerateBloodPressureStagesMap()
        {
            return new List<BloodPressureStage>()
            {
                new BloodPressureStage(
                    new Range(0, SystolicLowerLimitOfNormal),
                    new Range(0, DiastolicLowerLimitOfNormal),
                    BloodPressureStages.Hypotension,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertension),
                    new Range(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertension),
                    BloodPressureStages.Normotension,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitOfPrehypertension, SystolicLowerLimitOfStageIHypertension),
                    new Range(DiastolicLowerLimitOfPrehypertension, DiastolicLowerLimitOfStageIHypertension),
                    BloodPressureStages.PreHypertension,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitOfStageIHypertension, SystolicLowerLimitOfStageIIHypertension),
                    new Range(DiastolicLowerLimitOfStageIHypertension, DiastolicLowerLimitOfStageIIHypertension),
                    BloodPressureStages.StageIHypertension,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitOfStageIIHypertension, SystolicLowerLimitofHypertensiveUrgency),
                    new Range(DiastolicLowerLimitOfStageIIHypertension, DiastolicLowerLimitOfHypertensiveUrgency),
                    BloodPressureStages.StageIIHypertension,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitofHypertensiveUrgency, 500),
                    new Range(DiastolicLowerLimitOfHypertensiveUrgency, 500),
                    BloodPressureStages.HypertensiveUrgency,
                    false),
                new BloodPressureStage(
                    new Range(SystolicLowerLimitofHypertensiveUrgency, 500),
                    new Range(DiastolicLowerLimitOfHypertensiveUrgency, 500),
                    BloodPressureStages.HypertensiveEmergency,
                    true)
            };
        }
    }

    public class BloodPressureStage
    {
        public Range Systolic { get; set; }
        public Range Diastolic { get; set; }
        public BloodPressureStages Stage { get; set; }
        public bool EndOrganDamage { get; set; }

        public BloodPressureStage(Range systolic, Range diastolic, BloodPressureStages stage, bool endOrganDamage)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Stage = stage;
            EndOrganDamage = endOrganDamage;
        }

        public bool IsInStage(int systolic, int diastolic, bool endOrganDamage) =>
            (
                Stage == BloodPressureStages.HypertensiveEmergency &&  EndOrganDamage ? 
                (Systolic.IsInRange(systolic) || Diastolic.IsInRange(diastolic)) && endOrganDamage :
                (Systolic.IsInRange(systolic) || Diastolic.IsInRange(diastolic))
            );
    }

    public class Range
    {
        public int Upper { get; set; }
        public int Lower { get; set; }

        public Range(int lower, int upper)
        {
            Lower = lower;
            Upper = upper;
        }
        
        public bool IsInRange(int z) => (z >= Lower && z < Upper);
    }
}
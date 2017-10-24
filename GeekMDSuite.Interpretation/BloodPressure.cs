using System.Collections.Generic;
using GeekMDSuite.Contracts;
using GeekMDSuite.Interpretation.Tools;

namespace GeekMDSuite.Interpretation
{
    public static class BloodPressure
    {
        // API user likely to need access to these values when generating UI's
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

        public static BloodPressureStages Interpret(BloodPressureParameters parameters)
        {
            var list = GetDescriptorList();
            
            return Parse(new BloodPressureParameters(parameters.Systolic, parameters.Diastolic, parameters.OrganDamage), list);
            
        }

        private static BloodPressureStages Parse(BloodPressureParameters parameters, List<BloodPressureStageDescriptor> list)
        {
            var stage = BloodPressureStages.Normotension;

            foreach (var entry in list)
            {
                if (entry.IsInStage(parameters.Systolic, parameters.Diastolic, parameters.OrganDamage)) stage = entry.Stage;
            }
            return stage;
        }
        
        private class BloodPressureStageDescriptor
        {
            public Range Systolic { get; set; }
            public Range Diastolic { get; set; }
            public BloodPressureStages Stage { get; set; }
            public bool OrganDamage { get; set; }

            public BloodPressureStageDescriptor(Range systolic, Range diastolic, BloodPressureStages stage, bool organDamage)
            {
                Systolic = systolic;
                Diastolic = diastolic;
                Stage = stage;
                OrganDamage = organDamage;
            }

            public bool IsInStage(int systolic, int diastolic, bool organDamage) =>
            (
                Stage == BloodPressureStages.HypertensiveEmergency &&  OrganDamage ? 
                    (Systolic.IsInRange(systolic) || Diastolic.IsInRange(diastolic)) && organDamage :
                    (Systolic.IsInRange(systolic) || Diastolic.IsInRange(diastolic))
            );
        }
        private static List<BloodPressureStageDescriptor> GetDescriptorList()
        {
            var floorPressure = 0;
            var ceilingPressure = 500;
            return new List<BloodPressureStageDescriptor>()
            {
                new BloodPressureStageDescriptor(
                    new Range(floorPressure, SystolicLowerLimitOfNormal),
                    new Range(floorPressure, DiastolicLowerLimitOfNormal),
                    BloodPressureStages.Hypotension,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertension),
                    new Range(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertension),
                    BloodPressureStages.Normotension,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitOfPrehypertension, SystolicLowerLimitOfStageIHypertension),
                    new Range(DiastolicLowerLimitOfPrehypertension, DiastolicLowerLimitOfStageIHypertension),
                    BloodPressureStages.PreHypertension,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitOfStageIHypertension, SystolicLowerLimitOfStageIIHypertension),
                    new Range(DiastolicLowerLimitOfStageIHypertension, DiastolicLowerLimitOfStageIIHypertension),
                    BloodPressureStages.StageIHypertension,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitOfStageIIHypertension, SystolicLowerLimitofHypertensiveUrgency),
                    new Range(DiastolicLowerLimitOfStageIIHypertension, DiastolicLowerLimitOfHypertensiveUrgency),
                    BloodPressureStages.StageIIHypertension,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Range(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveUrgency,
                    false),
                new BloodPressureStageDescriptor(
                    new Range(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Range(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveEmergency,
                    true)
            };
        }
    }
}
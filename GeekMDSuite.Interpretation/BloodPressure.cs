using System.Collections.Generic;
using GeekMDSuite.Calculations;
using GeekMDSuite.Common;
using GeekMDSuite.Common.Tools;

namespace GeekMDSuite.Interpretation
{
    public static class BloodPressure
    {
        public static BloodPressureStages Interpret(BloodPressureParameters parameters)
        {
            var interpretation = BloodPressureStages.Normotension;
            foreach (var description in GetBloodPressureStageDescriptions())
            {
                if (description.Contains(parameters))
                    interpretation = description.Stage;
            }
            return interpretation;
        }
        
        private static List<StageDescription> GetBloodPressureStageDescriptions()
        {
            var floorPressure = 0;
            var ceilingPressure = 500;
            return new List<StageDescription>()
            {
                new StageDescription(
                    new Interval<int>(floorPressure, SystolicLowerLimitOfNormal),
                    new Interval<int>(floorPressure, DiastolicLowerLimitOfNormal),
                    BloodPressureStages.Hypotension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertension),
                    new Interval<int>(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertension),
                    BloodPressureStages.Normotension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfPrehypertension, SystolicLowerLimitOfStage1Hypertension),
                    new Interval<int>(DiastolicLowerLimitOfPrehypertension, DiastolicLowerLimitOfStage1Hypertension),
                    BloodPressureStages.PreHypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfStage1Hypertension, SystolicLowerLimitOfStage2Hypertension),
                    new Interval<int>(DiastolicLowerLimitOfStage1Hypertension, DiastolicLowerLimitOfStage2Hypertension),
                    BloodPressureStages.StageIHypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfStage2Hypertension, SystolicLowerLimitofHypertensiveUrgency),
                    new Interval<int>(DiastolicLowerLimitOfStage2Hypertension, DiastolicLowerLimitOfHypertensiveUrgency),
                    BloodPressureStages.StageIIHypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Interval<int>(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveUrgency,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Interval<int>(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveEmergency,
                    true)
            };
        }
        
        private struct StageDescription
        {
            public Interval<int> SystolicInterval { get; }
            public Interval<int> DiastolicInterval { get; }
            public BloodPressureStages Stage { get; }
            public bool OrganDamage { get; }

            public StageDescription(Interval<int> systolicInterval, Interval<int> diastolicInterval, BloodPressureStages stage, bool organDamage)
            {
                SystolicInterval = systolicInterval;
                DiastolicInterval = diastolicInterval;
                Stage = stage;
                OrganDamage = organDamage;
            }

            public bool Contains(BloodPressureParameters parameters) =>
            (
                Stage == BloodPressureStages.HypertensiveEmergency &&  OrganDamage ? 
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic)) && parameters.OrganDamage :
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic))
            );
        }
        
        // API consumer likely to need access to these values when developing user interfaces.
        public static readonly int SystolicLowerLimitOfNormal = 100;
        public static readonly int SystolicLowerLimitOfPrehypertension = 120;
        public static readonly int SystolicLowerLimitOfStage1Hypertension = 140;
        public static readonly int SystolicLowerLimitOfStage2Hypertension = 160;
        public static readonly int SystolicLowerLimitofHypertensiveUrgency = 180;
        public static readonly int DiastolicLowerLimitOfNormal = 60;
        public static readonly int DiastolicLowerLimitOfPrehypertension = 80;
        public static readonly int DiastolicLowerLimitOfStage1Hypertension = 90;
        public static readonly int DiastolicLowerLimitOfStage2Hypertension = 100;
        public static readonly int DiastolicLowerLimitOfHypertensiveUrgency = 120;
        
    }
}
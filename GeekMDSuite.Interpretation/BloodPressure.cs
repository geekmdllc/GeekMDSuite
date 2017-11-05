using System.Collections.Generic;
using GeekMDSuite.Calculations;
using GeekMDSuite.Common;
using GeekMDSuite.Interpretation.Tools;

namespace GeekMDSuite.Interpretation
{

    public static class BloodPressure
    {
        // API consumer likely to need access to these values when developing user interfaces.
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
            return GetInterpretation(parameters);
        }

        private static BloodPressureStages GetInterpretation(BloodPressureParameters parameters)
        {
            var interpretation = BloodPressureStages.Normotension;
            foreach (var description in GetBloodPressureStageDescriptions())
            {
                if (description.Contains(parameters))
                    interpretation = description.Stage;
            }
            return interpretation;
        }

        private struct StageDescription
        {
            public IntegerRange SystolicRange { get; }
            public IntegerRange DiastolicRange { get; }
            public BloodPressureStages Stage { get; }
            public bool OrganDamage { get; }

            public StageDescription(IntegerRange systolicRange, IntegerRange diastolicRange, BloodPressureStages stage, bool organDamage)
            {
                SystolicRange = systolicRange;
                DiastolicRange = diastolicRange;
                Stage = stage;
                OrganDamage = organDamage;
            }

            public bool Contains(BloodPressureParameters parameters) =>
            (
                Stage == BloodPressureStages.HypertensiveEmergency &&  OrganDamage ? 
                    (SystolicRange.Contains(parameters.Systolic) || DiastolicRange.Contains(parameters.Diastolic)) && parameters.OrganDamage :
                    (SystolicRange.Contains(parameters.Systolic) || DiastolicRange.Contains(parameters.Diastolic))
            );
        }
        
        private static List<StageDescription> GetBloodPressureStageDescriptions()
        {
            var floorPressure = 0;
            var ceilingPressure = 500;
            return new List<StageDescription>()
            {
                new StageDescription(
                    new IntegerRange(floorPressure, SystolicLowerLimitOfNormal),
                    new IntegerRange(floorPressure, DiastolicLowerLimitOfNormal),
                    BloodPressureStages.Hypotension,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertension),
                    new IntegerRange(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertension),
                    BloodPressureStages.Normotension,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitOfPrehypertension, SystolicLowerLimitOfStageIHypertension),
                    new IntegerRange(DiastolicLowerLimitOfPrehypertension, DiastolicLowerLimitOfStageIHypertension),
                    BloodPressureStages.PreHypertension,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitOfStageIHypertension, SystolicLowerLimitOfStageIIHypertension),
                    new IntegerRange(DiastolicLowerLimitOfStageIHypertension, DiastolicLowerLimitOfStageIIHypertension),
                    BloodPressureStages.StageIHypertension,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitOfStageIIHypertension, SystolicLowerLimitofHypertensiveUrgency),
                    new IntegerRange(DiastolicLowerLimitOfStageIIHypertension, DiastolicLowerLimitOfHypertensiveUrgency),
                    BloodPressureStages.StageIIHypertension,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new IntegerRange(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveUrgency,
                    false),
                new StageDescription(
                    new IntegerRange(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new IntegerRange(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveEmergency,
                    true)
            };
        }
        
        
    }
}
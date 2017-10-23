namespace GeekMDSuite.Interpretation.Procedures
{
    public static class BloodPressureInterpretation
    {
        public static readonly int SystolicLowerLimitOfNormal = 100;
        public static readonly int SystolicLowerLimitOfPrehypertensive = 120;
        public static readonly int SystolicLowerLimitOfStageIHypertension = 140;
        public static readonly int SystolicLowerLimitOfStageIIHypertension = 160;
        public static readonly int SystolicLowerLimitofHypertensiveUrgency = 180;
        public static readonly int DiastolicLowerLimitOfNormal = 60;
        public static readonly int DiastolicLowerLimitOfPrehypertensive = 80;
        public static readonly int DiastolicLowerLimitOfStageIHypertension = 90;
        public static readonly int DiastolicLowerLimitOfStageIIHypertension = 100; 
        public static readonly int DiastolicLowerLimitOfHypertensiveUrgency = 120;       

        public static BloodPressureStages Interpret (int systolicBp, int diastolicBp, bool endOrganDamagePresent)
        {
            bool IsInRange(int x, int y, int z) => (z >= x && z <= y);

            var staging = BloodPressureStages.Normotension;

            if(IsInRange(0,SystolicLowerLimitOfNormal - 1, systolicBp) || 
               IsInRange(0, DiastolicLowerLimitOfNormal - 1, diastolicBp)) {
                staging = BloodPressureStages.Hypotension;
            }
            if(IsInRange(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertensive - 1, systolicBp) &&
               IsInRange(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertensive - 1, diastolicBp)) {
                staging = BloodPressureStages.Normotension;
            }
            if(IsInRange(SystolicLowerLimitOfPrehypertensive, SystolicLowerLimitOfStageIHypertension - 1, systolicBp) ||
               IsInRange(DiastolicLowerLimitOfPrehypertensive, DiastolicLowerLimitOfStageIHypertension - 1, diastolicBp)) {
                staging = BloodPressureStages.PreHypertension;
            }
            if(IsInRange(SystolicLowerLimitOfStageIHypertension, SystolicLowerLimitOfStageIIHypertension - 1, systolicBp) ||
               IsInRange(DiastolicLowerLimitOfStageIHypertension, DiastolicLowerLimitOfStageIIHypertension - 1, diastolicBp)) {
                staging = BloodPressureStages.StageIHypertension;
            }
            if(IsInRange(SystolicLowerLimitOfStageIIHypertension, SystolicLowerLimitofHypertensiveUrgency - 1, systolicBp) ||
               IsInRange(DiastolicLowerLimitOfStageIIHypertension, DiastolicLowerLimitOfHypertensiveUrgency - 1, diastolicBp)) {
                staging = BloodPressureStages.StageIIHypertension;
            }
            if(systolicBp > SystolicLowerLimitofHypertensiveUrgency || 
               diastolicBp > DiastolicLowerLimitOfHypertensiveUrgency) {
                staging = BloodPressureStages.HypertensiveUrgency;

                switch(endOrganDamagePresent) {
                    case true:
                        staging = BloodPressureStages.HypertensiveEmergency;
                        break;
                    default:
                        staging = BloodPressureStages.HypertensiveUrgency;
                        break;
                }
            }
            return staging;
        }
    }
}
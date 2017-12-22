﻿namespace GeekMDSuite.Services.Interpretation
{
    public class CentralBloodPressureInterpretationResult
    {
        public CentralBloodPressureInterpretationResult(CentralBloodPressureCategory category, CentralBloodPressureReferenceAge referenceAge)
        {
            Category = category;
            ReferenceAge = referenceAge;
        }

        public CentralBloodPressureCategory Category { get; }
        // ReSharper disable once MemberCanBePrivate.Global
        public CentralBloodPressureReferenceAge ReferenceAge { get; }

        public override string ToString() => $"Category: {Category}, Reference Age: {ReferenceAge}";
    }
}
﻿namespace GeekMDSuite
{
    public interface IPatient
    {
        IGender Gender { get; }
        ILengthMeasurement Height { get; }
        IMassMeasurement BodyWeight { get; }
        ILengthMeasurement Waist { get; }
        double PercentBodyFat { get; }
        Race Race { get; }
        IVitalSigns Vitals { get; }
    }
}
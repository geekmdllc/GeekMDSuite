using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class MuscularStrengthInterpretation : IInterpretable<FitnessClassification>, IStrengthTestRanges
    {
        protected MuscularStrengthInterpretation(IMuscularStrengthTest test, IPatient patient)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _test = test ?? throw new ArgumentNullException(nameof(test));

            if (_test.Type == MuscularStrengthTest.Pushups)
                _ranges = PushupsRepository.GetRanges(_patient);
            else if (_test.Type == MuscularStrengthTest.Situps)
                _ranges = SitupsRepository.GetRanges(_patient);
            else if (_test.Type == MuscularStrengthTest.SitAndReach)
                _ranges = SitAndReachRepository.GetRanges(_patient);
            else 
                throw new NotImplementedException(nameof(_test.Type));
        }

        public double LowerLimitOfPoor => _ranges.LowerLimitOfPoor;
        public double LowerLimitOfBelowAverage => _ranges.LowerLimitOfBelowAverage;
        public double LowerLimitOfAverage => _ranges.LowerLimitOfAverage;
        public double LowerLimitOfAboveAverage => _ranges.LowerLimitOfAboveAverage;
        public double LowerLimitOfGood => _ranges.LowerLimitOfGood;
        public double LowerLimitOfExcellent => _ranges.LowerLimitOfExcellent;

        public override string ToString() => Classification.ToString();

        public InterpretationText Interpretation => throw new NotImplementedException();
        public FitnessClassification Classification => Classify();

        private readonly IMuscularStrengthTest _test;
        private readonly IStrengthTestRanges _ranges;
        private readonly IPatient _patient;

        private FitnessClassification Classify()
        {
            var limits = new StrengthTestLowerLimits(
                LowerLimitOfPoor,
                LowerLimitOfBelowAverage,
                LowerLimitOfAverage,
                LowerLimitOfAboveAverage,
                LowerLimitOfGood,
                LowerLimitOfExcellent);
            
            return ParseCountToFitnessClassification(limits);
        }
  
        private FitnessClassification ParseCountToFitnessClassification(IStrengthTestRanges lowerLimits) 
        {
            if (_test.Value < lowerLimits.LowerLimitOfPoor) 
                return FitnessClassification.VeryPoor;
            if (_test.Value < lowerLimits.LowerLimitOfBelowAverage) 
                return FitnessClassification.Poor;
            if (_test.Value < lowerLimits.LowerLimitOfAverage) 
                return FitnessClassification.BelowAverage;
            if (_test.Value < lowerLimits.LowerLimitOfAboveAverage) 
                return FitnessClassification.Average;
            if (_test.Value < lowerLimits.LowerLimitOfGood) 
                return FitnessClassification.AboveAverage;
            return _test.Value < lowerLimits.LowerLimitOfExcellent ? FitnessClassification.Good 
                : FitnessClassification.Excellent;
        }

        private class StrengthTestLowerLimits : IStrengthTestRanges
        {
            public StrengthTestLowerLimits(double poor, double belowAvg, double average, double aboveAvg, double good, double excellent)
            {
                LowerLimitOfPoor = poor;
                LowerLimitOfBelowAverage = belowAvg;
                LowerLimitOfAverage = average;
                LowerLimitOfAboveAverage = aboveAvg;
                LowerLimitOfGood = good;
                LowerLimitOfExcellent = excellent;
            }

            public double LowerLimitOfPoor { get; }
            public double LowerLimitOfBelowAverage { get; }
            public double LowerLimitOfAverage { get; }
            public double LowerLimitOfAboveAverage { get; }
            public double LowerLimitOfGood { get; }
            public double LowerLimitOfExcellent { get; }
        }
    }
}
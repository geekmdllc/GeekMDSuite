using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class MuscularStrengthInterpretation : IInterpretable<FitnessClassification>
    {
        protected MuscularStrengthInterpretation(IMuscularStrengthTest test, IPatient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            _test = test ?? throw new ArgumentNullException(nameof(test));

            if (_test.Type == MuscularStrengthTest.Pushups)
                _ranges = PushupsRepository.GetValues(patient);
            else if (_test.Type == MuscularStrengthTest.Situps)
                _ranges = SitupsRepository.GetValues(patient);
        }

        public int LowerLimitOfPoor => _ranges.LowerLimitOfPoor;
        public int LowerLimitOfBelowAverage => _ranges.LowerLimitOfBelowAverage;
        public int LowerLimitOfAverage => _ranges.LowerLimitOfAverage;
        public int LowerLimitOfAboveAverage => _ranges.LowerLimitOfAboveAverage;
        public int LowerLimitOfGood => _ranges.LowerLimitOfGood;
        public int LowerLimitOfExcellent => _ranges.LowerLimitOfExcellent;
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public FitnessClassification Classification => Classify();

        private readonly IMuscularStrengthTest _test;
        private readonly IStrengthTestRanges _ranges;
        
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
            if (_test.Count < lowerLimits.LowerLimitOfPoor) 
                return FitnessClassification.VeryPoor;
            if (_test.Count < lowerLimits.LowerLimitOfBelowAverage) 
                return FitnessClassification.Poor;
            if (_test.Count < lowerLimits.LowerLimitOfAverage) 
                return FitnessClassification.BelowAverage;
            if (_test.Count < lowerLimits.LowerLimitOfAboveAverage) 
                return FitnessClassification.Average;
            if (_test.Count < lowerLimits.LowerLimitOfGood) 
                return FitnessClassification.AboveAverage;
            return _test.Count < lowerLimits.LowerLimitOfExcellent ? FitnessClassification.Good 
                : FitnessClassification.Excellent;
        }

        private IStrengthTestRanges MapLimits(MuscularStrengthRepositoryEntry entry)
        {
            return new StrengthTestLowerLimits(
                entry.LowerLimitOfPoor,
                entry.LowerLimitOfBelowAverage,
                entry.LowerLimitOfAverage,
                entry.LowerLimitOfAboveAverage,
                entry.LowerLimitOfGood,
                entry.LowerLimitOfExcellent);
        }
        
        private class StrengthTestLowerLimits : IStrengthTestRanges
        {
            public StrengthTestLowerLimits(int poor, int belowAvg, int average, int aboveAvg, int good, int excellent)
            {
                LowerLimitOfPoor = poor;
                LowerLimitOfBelowAverage = belowAvg;
                LowerLimitOfAverage = average;
                LowerLimitOfAboveAverage = aboveAvg;
                LowerLimitOfGood = good;
                LowerLimitOfExcellent = excellent;
            }

            public int LowerLimitOfPoor { get; }
            public int LowerLimitOfBelowAverage { get; }
            public int LowerLimitOfAverage { get; }
            public int LowerLimitOfAboveAverage { get; }
            public int LowerLimitOfGood { get; }
            public int LowerLimitOfExcellent { get; }
        }
    }
}
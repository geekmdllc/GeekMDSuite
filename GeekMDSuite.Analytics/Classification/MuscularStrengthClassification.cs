using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public abstract class MuscularStrengthClassification : IClassifiable<FitnessClassification>, IStrengthTestRanges
    {
        private readonly IStrengthTestRanges _ranges;

        private readonly MuscularStrengthTest _test;

        protected MuscularStrengthClassification(MuscularStrengthTest test, Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            _test = test ?? throw new ArgumentNullException(nameof(test));

            if (_test.Type == StrengthTest.Pushups)
                _ranges = PushupsRepository.GetRanges(patient);
            else if (_test.Type == StrengthTest.Situps)
                _ranges = SitupsRepository.GetRanges(patient);
            else if (_test.Type == StrengthTest.SitAndReach)
                _ranges = SitAndReachRepository.GetRanges(patient);
            else
                throw new NotImplementedException(nameof(_test.Type));
        }

        public FitnessClassification Classification => Classify();

        public double LowerLimitOfPoor => _ranges.LowerLimitOfPoor;
        public double LowerLimitOfBelowAverage => _ranges.LowerLimitOfBelowAverage;
        public double LowerLimitOfAverage => _ranges.LowerLimitOfAverage;
        public double LowerLimitOfAboveAverage => _ranges.LowerLimitOfAboveAverage;
        public double LowerLimitOfGood => _ranges.LowerLimitOfGood;
        public double LowerLimitOfExcellent => _ranges.LowerLimitOfExcellent;

        public override string ToString()
        {
            return Classification.ToString();
        }

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
            return _test.Value < lowerLimits.LowerLimitOfExcellent
                ? FitnessClassification.Good
                : FitnessClassification.Excellent;
        }

        private class StrengthTestLowerLimits : IStrengthTestRanges
        {
            public StrengthTestLowerLimits(double poor, double belowAvg, double average, double aboveAvg, double good,
                double excellent)
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
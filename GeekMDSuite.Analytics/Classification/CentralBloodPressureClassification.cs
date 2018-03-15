using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using MathNet.Numerics.Distributions;

namespace GeekMDSuite.Analytics.Classification
{
    public class CentralBloodPressureClassification : IClassifiable<CentralBloodPressureClassificationResult>
    {
        private static readonly Dictionary<CentralBloodPressureCategory, int> CategoryValueMap =
            new Dictionary<CentralBloodPressureCategory, int>
            {
                {CentralBloodPressureCategory.Low, 1},
                {CentralBloodPressureCategory.LowNormal, 2},
                {CentralBloodPressureCategory.Normal, 3},
                {CentralBloodPressureCategory.HighNormal, 4},
                {CentralBloodPressureCategory.High, 5}
            };

        private readonly CentralBloodPressure _centralBloodPressure;
        private readonly Patient _patient;

        public CentralBloodPressureClassification(CentralBloodPressureParameters parameters)
        {
            _centralBloodPressure =
                parameters.CentralBloodPressure ??
                throw new ArgumentNullException(nameof(parameters.CentralBloodPressure));
            _patient = parameters.Patient ?? throw new ArgumentNullException(nameof(parameters.Patient));
        }

        private int AgeReferenceGroupUpperLimit
        {
            get
            {
                if (_patient.Age <= 20) return 20;
                if (_patient.Age <= 29) return 29;
                if (_patient.Age <= 39) return 39;
                if (_patient.Age <= 49) return 49;
                if (_patient.Age <= 59) return 59;
                if (_patient.Age <= 69) return 69;
                return _patient.Age <= 79 ? 79 : 90;
            }
        }

        public CentralBloodPressureClassificationResult Classification => ClassifyBasedOnWorstResult();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private CentralBloodPressureClassificationResult ClassifyBasedOnWorstResult()
        {
            var highestPriorityValue = GetHighestPriorityValue();

            var category = CategoryValueMap.FirstOrDefault(v => v.Value == highestPriorityValue).Key;
            var referenceAge = ClassifyReferenceAge();

            return new CentralBloodPressureClassificationResult(category, referenceAge);
        }

        private int GetHighestPriorityValue()
        {
            var resultList = GetTestResults();

            var maxValueResult = resultList.Select(result => CategoryValueMap[result]).Max();
            var minValueResult = resultList.Select(result => CategoryValueMap[result]).Min();
            var normalValue = CategoryValueMap[CentralBloodPressureCategory.Normal];

            var highestPriorityValue = normalValue;
            if (minValueResult < normalValue && maxValueResult <= normalValue)
                highestPriorityValue = minValueResult;
            if (maxValueResult > normalValue)
                highestPriorityValue = maxValueResult;

            return highestPriorityValue;
        }

        private List<CentralBloodPressureCategory> GetTestResults()
        {
            return new List<CentralBloodPressureCategory>
            {
                CentralSystolicPressure(),
                PulsePressure(),
                AugmentedPressure(),
                AugmentedIndex(),
                PulseWaveVelocity()
            };
        }

        private CentralBloodPressureCategory CentralSystolicPressure()
        {
            return CategoryFromPercentile(CentralSystolicPressurePercentile());
        }

        private CentralBloodPressureCategory PulsePressure()
        {
            return CategoryFromPercentile(PulsePressurePercentile());
        }

        private CentralBloodPressureCategory AugmentedPressure()
        {
            return CategoryFromPercentile(AugmentedPressurePercentile());
        }

        private CentralBloodPressureCategory AugmentedIndex()
        {
            return CategoryFromPercentile(AugmentedIndexPercentile());
        }

        private CentralBloodPressureCategory PulseWaveVelocity()
        {
            return CategoryFromPercentile(PulseWaveVelocityPercentile());
        }

        private CentralBloodPressureReferenceAge ClassifyReferenceAge()
        {
            if (_centralBloodPressure.ReferenceAge <= _patient.Age - 10)
                return CentralBloodPressureReferenceAge.MuchYoungerThanStated;
            if (_centralBloodPressure.ReferenceAge <= _patient.Age - 2)
                return CentralBloodPressureReferenceAge.YoungerThanStated;
            if (_centralBloodPressure.ReferenceAge < _patient.Age + 2)
                return CentralBloodPressureReferenceAge.SimilarToStated;
            return _centralBloodPressure.ReferenceAge < _patient.Age + 10
                ? CentralBloodPressureReferenceAge.OlderThanStated
                : CentralBloodPressureReferenceAge.YoungerThanStated;
        }

        private double CentralSystolicPressurePercentile()
        {
            var population = Gender.IsGenotypeXy(_patient.Gender)
                ? PopulationValues.CentralSystolic.Male.FirstOrDefault(group =>
                    group.AgeUpperLimit == AgeReferenceGroupUpperLimit)
                : PopulationValues.CentralSystolic.Female.FirstOrDefault(group =>
                    group.AgeUpperLimit == AgeReferenceGroupUpperLimit);

            return GetPercentileForTest(population, _centralBloodPressure.SystolicPressure);
        }

        private double PulsePressurePercentile()
        {
            var male = PopulationValues.PulsePressure.Male.FirstOrDefault(p =>
                p.AgeUpperLimit == AgeReferenceGroupUpperLimit);
            var female =
                PopulationValues.PulsePressure.Female.FirstOrDefault(
                    p => p.AgeUpperLimit == AgeReferenceGroupUpperLimit);

            return Gender.IsGenotypeXy(_patient.Gender)
                ? GetPercentileForTest(male, _centralBloodPressure.PulsePressure)
                : GetPercentileForTest(female, _centralBloodPressure.PulsePressure);
        }

        private double AugmentedPressurePercentile()
        {
            var male = PopulationValues.AugmentedPressure.Male.FirstOrDefault(p =>
                p.AgeUpperLimit == AgeReferenceGroupUpperLimit);
            var female =
                PopulationValues.AugmentedPressure.Female.FirstOrDefault(p =>
                    p.AgeUpperLimit == AgeReferenceGroupUpperLimit);

            return Gender.IsGenotypeXy(_patient.Gender)
                ? GetPercentileForTest(male, _centralBloodPressure.AugmentedPressure)
                : GetPercentileForTest(female, _centralBloodPressure.AugmentedPressure);
        }

        private double AugmentedIndexPercentile()
        {
            var male = PopulationValues.AugmentedIndex.Male.FirstOrDefault(p =>
                p.AgeUpperLimit == AgeReferenceGroupUpperLimit);
            var female =
                PopulationValues.AugmentedIndex.Female.FirstOrDefault(p =>
                    p.AgeUpperLimit == AgeReferenceGroupUpperLimit);

            return Gender.IsGenotypeXy(_patient.Gender)
                ? GetPercentileForTest(male, _centralBloodPressure.AugmentedIndex)
                : GetPercentileForTest(female, _centralBloodPressure.AugmentedIndex);
        }

        private double PulseWaveVelocityPercentile()
        {
            var male = PopulationValues.PulseWaveVelocity.Male.FirstOrDefault(p =>
                p.AgeUpperLimit == AgeReferenceGroupUpperLimit);
            var female =
                PopulationValues.PulseWaveVelocity.Female.FirstOrDefault(p =>
                    p.AgeUpperLimit == AgeReferenceGroupUpperLimit);

            return Gender.IsGenotypeXy(_patient.Gender)
                ? GetPercentileForTest(male, _centralBloodPressure.PulseWaveVelocity)
                : GetPercentileForTest(female, _centralBloodPressure.PulseWaveVelocity);
        }

        private double GetPercentileForTest(PopulationTestData data, double test)
        {
            return Percentile(data.Mean, data.StandardDeviation, test);
        }

        private static double Percentile(double mean, double standardDeviation, double dataPoint)
        {
            return Normal.CDF(mean, standardDeviation, dataPoint) * 100.0;
        }

        private static CentralBloodPressureCategory CategoryFromPercentile(double percentile)
        {
            if (percentile <= 5) return CentralBloodPressureCategory.Low;
            if (percentile <= 16) return CentralBloodPressureCategory.LowNormal;
            if (percentile <= 84) return CentralBloodPressureCategory.Normal;
            return percentile <= 95 ? CentralBloodPressureCategory.HighNormal : CentralBloodPressureCategory.High;
        }

        private class PopulationTestData
        {
            public PopulationTestData(int ageUpperLimit, double mean, double standardDeviation)
            {
                AgeUpperLimit = ageUpperLimit;
                Mean = mean;
                StandardDeviation = standardDeviation;
            }

            public int AgeUpperLimit { get; }
            public double Mean { get; }
            public double StandardDeviation { get; }
        }

        private static class PopulationValues
        {
            public static class CentralSystolic
            {
                public static readonly List<PopulationTestData> Male = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 103, 8),
                    new PopulationTestData(29, 105, 8),
                    new PopulationTestData(39, 109, 9),
                    new PopulationTestData(49, 113, 9),
                    new PopulationTestData(59, 115, 9),
                    new PopulationTestData(69, 117, 9),
                    new PopulationTestData(79, 118, 9),
                    new PopulationTestData(90, 120, 8)
                };

                public static readonly List<PopulationTestData> Female = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 98, 9),
                    new PopulationTestData(29, 101, 9),
                    new PopulationTestData(39, 105, 11),
                    new PopulationTestData(49, 109, 11),
                    new PopulationTestData(59, 115, 11),
                    new PopulationTestData(69, 118, 10),
                    new PopulationTestData(79, 119, 9),
                    new PopulationTestData(90, 120, 11)
                };
            }

            public static class PulsePressure
            {
                public static readonly List<PopulationTestData> Male = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 29, 3),
                    new PopulationTestData(29, 30, 6),
                    new PopulationTestData(39, 31, 6),
                    new PopulationTestData(49, 34, 6),
                    new PopulationTestData(59, 35, 7),
                    new PopulationTestData(69, 39, 7),
                    new PopulationTestData(79, 42, 7),
                    new PopulationTestData(90, 45, 9)
                };

                public static readonly List<PopulationTestData> Female = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 25, 6),
                    new PopulationTestData(29, 27, 7),
                    new PopulationTestData(39, 30, 8),
                    new PopulationTestData(49, 33, 8),
                    new PopulationTestData(59, 38, 8),
                    new PopulationTestData(69, 43, 8),
                    new PopulationTestData(79, 56, 8),
                    new PopulationTestData(90, 49, 12)
                };
            }

            public static class AugmentedPressure
            {
                public static readonly List<PopulationTestData> Male = new List<PopulationTestData>
                {
                    new PopulationTestData(20, -1, 3),
                    new PopulationTestData(29, 1, 4),
                    new PopulationTestData(39, 4, 5),
                    new PopulationTestData(49, 7, 4),
                    new PopulationTestData(59, 9, 5),
                    new PopulationTestData(69, 11, 5),
                    new PopulationTestData(79, 13, 5),
                    new PopulationTestData(90, 14, 5)
                };

                public static readonly List<PopulationTestData> Female = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 1, 3),
                    new PopulationTestData(29, 3, 4),
                    new PopulationTestData(39, 6, 5),
                    new PopulationTestData(49, 10, 5),
                    new PopulationTestData(59, 13, 5),
                    new PopulationTestData(69, 15, 5),
                    new PopulationTestData(79, 16, 5),
                    new PopulationTestData(90, 18, 7)
                };
            }

            public static class AugmentedIndex
            {
                public static readonly List<PopulationTestData> Male = new List<PopulationTestData>
                {
                    new PopulationTestData(20, -2, 8),
                    new PopulationTestData(29, 2, 11),
                    new PopulationTestData(39, 12, 13),
                    new PopulationTestData(49, 19, 10),
                    new PopulationTestData(59, 24, 10),
                    new PopulationTestData(69, 28, 9),
                    new PopulationTestData(79, 30, 9),
                    new PopulationTestData(90, 30, 10)
                };

                public static readonly List<PopulationTestData> Female = new List<PopulationTestData>
                {
                    new PopulationTestData(20, 5, 10),
                    new PopulationTestData(29, 9, 14),
                    new PopulationTestData(39, 20, 12),
                    new PopulationTestData(49, 28, 10),
                    new PopulationTestData(59, 33, 9),
                    new PopulationTestData(69, 34, 9),
                    new PopulationTestData(79, 35, 9),
                    new PopulationTestData(90, 37, 10)
                };
            }

            public static class PulseWaveVelocity
            {
                //TODO: Update with more robust data
                //Current data from: Merill F. Elias et al.| Pulse Wave Velocity
                public static List<PopulationTestData> Male => new List<PopulationTestData>
                {
                    new PopulationTestData(20, 8.1, 1.3),
                    new PopulationTestData(29, 8.1, 1.3),
                    new PopulationTestData(39, 8.1, 1.3),
                    new PopulationTestData(49, 8.0, 1.3),
                    new PopulationTestData(59, 8.9, 1.3),
                    new PopulationTestData(69, 10.1, 1.9),
                    new PopulationTestData(79, 11.4, 2.1),
                    new PopulationTestData(90, 11.4, 2.6)
                };

                public static List<PopulationTestData> Female => new List<PopulationTestData>
                {
                    new PopulationTestData(20, 8.1, 1.3),
                    new PopulationTestData(29, 8.1, 1.3),
                    new PopulationTestData(39, 8.1, 1.3),
                    new PopulationTestData(49, 8.0, 1.3),
                    new PopulationTestData(59, 8.9, 1.3),
                    new PopulationTestData(69, 10.1, 1.9),
                    new PopulationTestData(79, 11.4, 2.1),
                    new PopulationTestData(90, 11.4, 2.6)
                };
            }
        }
    }
}
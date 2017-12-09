using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Procedures;
using MathNet.Numerics.Distributions;

namespace GeekMDSuite.Services.Interpretation
{
    public class CentralBloodPressureInterpretation : IInterpretable<CentralBloodPressureCategory>
    {
        public CentralBloodPressureInterpretation(CentralBloodPressure centralBloodPressure, IPatient patient)
        {
            _centralBloodPressure = centralBloodPressure;
            _patient = patient;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public CentralBloodPressureCategory Classification => throw new NotImplementedException();
        
        private CentralBloodPressure _centralBloodPressure;
        private IPatient _patient;

        private double CentralSystolicPressurePercentile()
        {
            var male = PopulationValues.CentralSystolic.Male.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            var female = PopulationValues.CentralSystolic.Female.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            
            return Gender.IsGenotypeXy(_patient.Gender) 
                ? GetPercentileForTest(male, _centralBloodPressure.SystolicPressure)
                : GetPercentileForTest(female, _centralBloodPressure.SystolicPressure);
        }
        
        private double PulsePressurePercentile()
        {
            var male = PopulationValues.PulsePressure.Male.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            var female = PopulationValues.PulsePressure.Female.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            
            return Gender.IsGenotypeXy(_patient.Gender) 
                ? GetPercentileForTest(male, _centralBloodPressure.PulsePressure)
                : GetPercentileForTest(female, _centralBloodPressure.PulsePressure);
        }
        
        private double AugmentedPressurePercentile()
        {
            var male = PopulationValues.AugmentedPressure.Male.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            var female = PopulationValues.AugmentedPressure.Female.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            
            return Gender.IsGenotypeXy(_patient.Gender) 
                ? GetPercentileForTest(male, _centralBloodPressure.AugmentedPressure)
                : GetPercentileForTest(female, _centralBloodPressure.AugmentedPressure);
        }
        
        private double AugmentedIndexPercentile()
        {
            var male = PopulationValues.AugmentedIndex.Male.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            var female = PopulationValues.AugmentedIndex.Female.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            
            return Gender.IsGenotypeXy(_patient.Gender) 
                ? GetPercentileForTest(male, _centralBloodPressure.AugmentedIndex)
                : GetPercentileForTest(female, _centralBloodPressure.AugmentedIndex);
        }
        
        private double PulseWaveVelocityPercentile()
        {
            var male = PopulationValues.PulseWaveVelocity.Male.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            var female = PopulationValues.PulseWaveVelocity.Female.FirstOrDefault(p => p.Age == MaximumAgeForReferenceGroup);
            
            return Gender.IsGenotypeXy(_patient.Gender) 
                ? GetPercentileForTest(male, _centralBloodPressure.PulseWaveVelocity)
                : GetPercentileForTest(female, _centralBloodPressure.PulseWaveVelocity);
        }
             
        private int MaximumAgeForReferenceGroup 
        {
            get
            {
                if(_patient.Age <= 20) return 20;
                if(_patient.Age <= 29) return 29;
                if(_patient.Age <= 39) return 39;
                if(_patient.Age <= 49) return 49;
                if(_patient.Age <= 59) return 59;
                if(_patient.Age <= 69) return 69;
                return _patient.Age <= 79 ? 79 : 90;
            }
        }

        private class PopulationTestData
        {
            public PopulationTestData(int age, double mean, double standardDeviation)
            {
                Age = age;
                Mean = mean;
                StandardDeviation = standardDeviation;
            }

            public int Age { get; }
            public double Mean { get; }
            public double StandardDeviation { get; }
        }
        
        private static class PopulationValues
        {
            public static class CentralSystolic
            {
                public static List<PopulationTestData> Male = new List<PopulationTestData>()
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
                
                public static List<PopulationTestData> Female = new List<PopulationTestData>()
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
                public static List<PopulationTestData> Male = new List<PopulationTestData>()
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
                
                public static List<PopulationTestData> Female = new List<PopulationTestData>()
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
                public static List<PopulationTestData> Male = new List<PopulationTestData>()
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
                
                public static List<PopulationTestData> Female = new List<PopulationTestData>()
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
                public static List<PopulationTestData> Male = new List<PopulationTestData>()
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
                
                public static List<PopulationTestData> Female = new List<PopulationTestData>()
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
                public static List<PopulationTestData> Male => throw new NotImplementedException();
                public static List<PopulationTestData> Female => throw new NotImplementedException();
            }
        }
        
        private double GetPercentileForTest(PopulationTestData data, double test)
        {
            return Percentile(data.Mean, data.StandardDeviation, test);
        }

        private static double Percentile(double mean, double standardDeviation, double dataPoint)
        {
            return Normal.CDF(mean, standardDeviation, dataPoint) * 100;
        }
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class MuscularStrengthInterpretation : IInterpretable<FitnessClassification>
    {
        public abstract int LowerLimitOfPoor { get;  }
        public abstract int LowerLimitOfBelowAverage { get;  }
        public abstract int LowerLimitOfAverage { get;  }
        public abstract int LowerLimitOfAboveAverage { get;  }
        public abstract int LowerLimitOfGood { get;  }
        public abstract int LowerLimitOfExcellent { get;  }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public FitnessClassification Classification => throw new NotFiniteNumberException();

        private readonly IPatient _patient;
        private readonly int _count;

        protected MuscularStrengthInterpretation(IMuscularStrengthTest test, IPatient patient)
        {
            _count = test.Count;
            _patient = patient;
        }

        protected static bool IsInAgeRange(int lowerBound, int upperBound, int age) => 
            age >= lowerBound && age <= upperBound;

        protected FitnessClassification ExerciseCountAssessment(StrengthTestLowerLimits lowerLimits) 
        {
            if (_count < lowerLimits.Poor) 
                return FitnessClassification.VeryPoor;
            if (_count < lowerLimits.BelowAverage) 
                return FitnessClassification.Poor;
            if (_count < lowerLimits.Average) 
                return FitnessClassification.BelowAverage;
            if (_count < lowerLimits.AboveAverage) 
                return FitnessClassification.Average;
            if (_count < lowerLimits.Good) 
                return FitnessClassification.AboveAverage;
            return _count < lowerLimits.Excellent ? FitnessClassification.Good 
                : FitnessClassification.Excellent;
        }

        protected FitnessClassification Classify()
        {
            var limits = new StrengthTestLowerLimits(
                LowerLimitOfPoor,
                LowerLimitOfBelowAverage,
                LowerLimitOfAverage,
                LowerLimitOfAboveAverage,
                LowerLimitOfGood,
                LowerLimitOfExcellent);
            
            return ExerciseCountAssessment(limits);
        }
        protected int GetLowerBoundOfFitnessStratification(int[] list, List<Interval<int>> ageRanges)
        {
            if(list.Length !=6 || ageRanges.Count != 6) throw new IndexOutOfRangeException();

            if(ageRanges[0].ContainsOpen(_patient.Age)) return list[0];
            if(ageRanges[1].ContainsOpen(_patient.Age)) return list[1];
            if(ageRanges[2].ContainsOpen(_patient.Age)) return list[2];
            if(ageRanges[3].ContainsOpen(_patient.Age)) return list[3];
            return ageRanges[4].ContainsOpen(_patient.Age) ? list[4] : list[5];
        }
        
        protected int GetLowerLimitOfExerciseForPatient(int[] femaleList, int[] maleList, List<Interval<int>> ageRanges) {
            switch(Gender.IsGenotypeXx(_patient.Gender)) {
                case true:
                    return GetLowerBoundOfFitnessStratification(femaleList, ageRanges);
                default:
                    return GetLowerBoundOfFitnessStratification(maleList, ageRanges);
            }
        }

        private class PushupRanges
        {
            // Pushups
            private List<Interval<int>> AgeRanges = new List<Interval<int>>()
            {
                new Interval<int>(0,19),
                new Interval<int>(20,29),
                new Interval<int>(30,39),
                new Interval<int>(40,49),
                new Interval<int>(50,59),
                new Interval<int>(60,65),
                new Interval<int>(66,1000)
            };
    
            public int LowerLimitOfPoorAlt
            {
                get {
                    // Poor, Below Avg, Avg, Abov Avg, Good, Excellent; match w/ interval list
                    int[] maleList = {4,4,2,1,1,1};
                    int[] femaleList = {2,2,1,1,1,1};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfBelowAverageAlt
            {
                get {
                    int[] maleList = {11, 10, 8, 6, 5, 3};
                    int[] femaleList = {6, 7, 5, 4, 3, 2,};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfAverageAlt
            {
                get {
                    int[] maleList = {19, 17, 13, 11, 9, 6};
                    int[] femaleList = {11, 12, 10, 8, 7, 5};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfAboveAverageAlt
            {
                get {
                    int[] maleList = {35, 30, 25, 21, 18, 17};
                    int[] femaleList = {21, 23, 22, 18, 15, 13};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfGoodAlt
            {
                get {
                    int[] maleList = {47, 39, 34, 28, 25, 24};
                    int[] femaleList = {27, 30, 30, 25, 21, 19};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }  
            public int LowerLimitOfExcellentAlt
            {
                get {
                    int[] maleList = {56, 47, 41, 34, 31, 30};
                    int[] femaleList = {35, 36, 37, 31, 25, 23};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
                
            }
        }

        private class SitupRanges
        {
            private List<Interval<int>> AgeRanges = new List<Interval<int>>()
            {
                new Interval<int>(0,19),
                new Interval<int>(20,29),
                new Interval<int>(30,39),
                new Interval<int>(40,49),
                new Interval<int>(50,59),
                new Interval<int>(60,65),
                new Interval<int>(66,1000)
            };
            public int LowerLimitOfPoor 
            {
                
                get {
                    int[] maleList = {25, 22, 17, 13, 9, 7};
                    int[] femaleList = {18, 13, 7, 5, 3, 2};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfBelowAverage 
            {
                get {
                    int[] maleList = {31, 29, 23, 18, 13, 11};
                    int[] femaleList = {25, 21, 15, 10, 7, 5};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfAverage 
            {
                get {
                    int[] maleList = {35, 31, 27, 22, 17, 15};
                    int[] femaleList = {29, 25, 19, 14, 10, 11};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfAboveAverage 
            {
                get {
                    int[] maleList = {39, 35, 30, 25, 21, 19};
                    int[] femaleList = {33, 29, 23, 18, 13, 14};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }
            public int LowerLimitOfGood 
            {
                get {
                    int[] maleList = {44, 40, 35, 29, 25, 22};
                    int[] femaleList = {37, 33, 27, 22, 18, 17};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
            }  
            public int LowerLimitOfExcellent
            {
                get {
                    int[] maleList = {49, 45, 41, 35, 31, 28};
                    int[] femaleList = {43, 39, 33, 27, 24, 23};
                    return GetLowerLimitOfExerciseForPatient(femaleList, maleList, AgeRanges);
                }
                
            }
        }
    }
}
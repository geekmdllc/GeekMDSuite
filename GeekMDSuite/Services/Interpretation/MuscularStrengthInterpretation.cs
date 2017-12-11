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
        protected int GetLowerBoundOfFitnessStratification(int[] list, List<AgeRange> ageRanges)
        {
            var patientAge = _patient.Age;
            
            if(list.Length !=6 || ageRanges.Count != 6) throw new IndexOutOfRangeException();
            if(IsInAgeRange(ageRanges[0].Lower ,ageRanges[0].Upper, patientAge)) return list[0];
            if(IsInAgeRange(ageRanges[1].Lower ,ageRanges[1].Upper, patientAge)) return list[1];
            if(IsInAgeRange(ageRanges[2].Lower ,ageRanges[2].Upper, patientAge)) return list[2];
            if(IsInAgeRange(ageRanges[3].Lower ,ageRanges[3].Upper, patientAge)) return list[3];
            return IsInAgeRange(ageRanges[4].Lower ,ageRanges[4].Upper, patientAge) ? list[4] : list[5];
        }
        protected int GetLowerLimitOfExerciseForPatient(int[] femaleList, int[] maleList, List<AgeRange> ageRanges) {
            switch(Gender.IsGenotypeXx(_patient.Gender)) {
                case true:
                    return GetLowerBoundOfFitnessStratification(femaleList, ageRanges);
                default:
                    return GetLowerBoundOfFitnessStratification(maleList, ageRanges);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public abstract class MuscularStrengthInterpretation
    {
        private int _count;
        public abstract int LowerLimitOfPoor { get;  }
        public abstract int LowerLimitOfBelowAverage { get;  }
        public abstract int LowerLimitOfAverage { get;  }
        public abstract int LowerLimitOfAboveAverage { get;  }
        public abstract int LowerLimitOfGood { get;  }
        public abstract int LowerLimitOfExcellent { get;  }

        private readonly IPatient _patient;

        protected MuscularStrengthInterpretation(IPatient patient)
        {
            _patient = patient;
        }

        protected static bool IsInAgeRange(int lowerBound, int upperBound, int age) => age >= lowerBound && age <= upperBound;

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
        //TODO: convert to interval
        public class AgeRange {
            public int Upper { get; set; }
            public int Lower { get; set; }
        }
        protected int GetLowerBoundOfExerciseFitnessStratificationFromList(int[] list, List<AgeRange> ageRanges)
        {
            var patientAge = _patient.Age;
            
            if(list.Length !=6 || ageRanges.Count != 6) throw new IndexOutOfRangeException();
            if(IsInAgeRange(ageRanges[0].Lower ,ageRanges[0].Upper, patientAge)) return list[0];
            if(IsInAgeRange(ageRanges[1].Lower ,ageRanges[1].Upper, patientAge)) return list[1];
            if(IsInAgeRange(ageRanges[2].Lower ,ageRanges[2].Upper, patientAge)) return list[2];
            if(IsInAgeRange(ageRanges[3].Lower ,ageRanges[3].Upper, patientAge)) return list[3];
            return IsInAgeRange(ageRanges[4].Lower ,ageRanges[4].Upper, patientAge) ? list[4] : list[5];
        }
        protected int GetLowerLimitOfExerciseBoundForPatient(int[] femaleList, int[] maleList, List<AgeRange> ageRanges) {
            switch(Gender.IsGenotypeXx(_patient.Gender)) {
                case true:
                    return GetLowerBoundOfExerciseFitnessStratificationFromList(femaleList, ageRanges);
                default:
                    return GetLowerBoundOfExerciseFitnessStratificationFromList(maleList, ageRanges);
            }
        }
    }
    public enum FitnessClassification
    {
        VeryPoor,
        Poor,
        BelowAverage,
        Average,
        AboveAverage,
        Good,
        Excellent
    }
}
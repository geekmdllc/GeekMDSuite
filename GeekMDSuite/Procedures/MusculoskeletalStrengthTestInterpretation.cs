using System;
using System.Collections.Generic;

namespace GeekMDSuite.Procedures
{
    public class MusculoskeletalStrengthTestLowerLimits
    {
        public MusculoskeletalStrengthTestLowerLimits(
            int poor, 
            int belowAverage, 
            int average, 
            int aboveAverage, 
            int good, 
            int excellent)
        {
            Poor = poor;
            BelowAverage = belowAverage;
            Average = average;
            AboveAverage = aboveAverage;
            Good = good;
            Excellent = excellent;
        }

        public int Poor { get; }
        public int BelowAverage { get; }
        public int Average { get; }
        public int AboveAverage { get; }
        public int Good { get; }
        public int Excellent { get; }
    }

    public abstract class MusculoskeletalStrengthTestInterpretation
    {
        public int Count { get; set; }
        public abstract int LowerLimitOfPoor { get;  }
        public abstract int LowerLimitOfBelowAverage { get;  }
        public abstract int LowerLimitOfAverage { get;  }
        public abstract int LowerLimitOfAboveAverage { get;  }
        public abstract int LowerLimitOfGood { get;  }
        public abstract int LowerLimitOfExcellent { get;  }

        private readonly IPatient _patient;

        protected MusculoskeletalStrengthTestInterpretation(IPatient patient)
        {
            _patient = patient;
        }

        protected static bool IsInAgeRange(int lowerBound, int upperBound, int age) => age >= lowerBound && age <= upperBound;

        protected MusculoskeletalFitnessClassification ExerciseCountAssessment(MusculoskeletalStrengthTestLowerLimits lowerLimits) 
        {
            if (Count < lowerLimits.Poor) 
                return MusculoskeletalFitnessClassification.VeryPoor;
            if (Count < lowerLimits.BelowAverage) 
                return MusculoskeletalFitnessClassification.Poor;
            if (Count < lowerLimits.Average) 
                return MusculoskeletalFitnessClassification.BelowAverage;
            if (Count < lowerLimits.AboveAverage) 
                return MusculoskeletalFitnessClassification.Average;
            if (Count < lowerLimits.Good) 
                return MusculoskeletalFitnessClassification.AboveAverage;
            return Count < lowerLimits.Excellent ? MusculoskeletalFitnessClassification.Good 
                : MusculoskeletalFitnessClassification.Excellent;
        }

        protected MusculoskeletalFitnessClassification Classify()
        {
            var limits = new MusculoskeletalStrengthTestLowerLimits(
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
    public enum MusculoskeletalFitnessClassification
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
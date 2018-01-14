using System;
using GeekMDSuite.Analytics.Tools.Fitness;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class Vo2MaxClassification : IClassifiable<FitnessClassification>
    {
        private readonly Patient _patient;
        private readonly double _vo2Max;

        private Vo2MaxClassification(double vo2Max, Patient patient)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _vo2Max = vo2Max;
        }

        public Vo2MaxClassification(Vo2MaxClassificationParameters parameters)
            : this(CalculateVo2Max.FromTreadmillStressTest(parameters.TreadmillExerciseTest, parameters.Patient),
                parameters.Patient)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.TreadmillExerciseTest == null)
                throw new ArgumentNullException(nameof(parameters.TreadmillExerciseTest));
        }

        public FitnessClassification Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private FitnessClassification Classify()
        {
            if (_patient.Age < 13) throw new ArgumentException("Age must be 13 or greater.");

            return Gender.IsGenotypeXx(_patient.Gender)
                ? GetFemaleClassification(_vo2Max, _patient.Age)
                : GetMaleClassification(_vo2Max, _patient.Age);
        }

        private static FitnessClassification GetMaleClassification(double vo2Max, double ageInYears)
        {
            if (ageInYears <= 25)
                return MaleUnder25Classification(vo2Max);
            if (ageInYears <= 35)
                return MaleUnder35Classification(vo2Max);
            if (ageInYears <= 45)
                return MaleUnder45Classification(vo2Max);
            if (ageInYears <= 55)
                return MaleUnder55Classification(vo2Max);
            return ageInYears <= 65 ? MaleUnder65Classification(vo2Max) : MaleOver65Classification(vo2Max);
        }

        private static FitnessClassification GetFemaleClassification(double vo2Max, double ageInYears)
        {
            if (ageInYears <= 25)
                return FemaleUnder25Classification(vo2Max);
            if (ageInYears <= 35)
                return FemaleUnder35Classification(vo2Max);
            if (ageInYears <= 45)
                return FemaleUnder45Classification(vo2Max);
            if (ageInYears <= 55)
                return FemaleUnder55Classification(vo2Max);
            return ageInYears <= 65 ? FemaleUnder65Classification(vo2Max) : FemaleOver65Classification(vo2Max);
        }

        private static FitnessClassification MaleOver65Classification(double vo2Max)
        {
            if (vo2Max > 37)
                return FitnessClassification.Excellent;
            if (vo2Max >= 33)
                return FitnessClassification.Good;
            if (vo2Max >= 29)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 26)
                return FitnessClassification.Average;
            if (vo2Max >= 22)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder65Classification(double vo2Max)
        {
            if (vo2Max > 41)
                return FitnessClassification.Excellent;
            if (vo2Max >= 36)
                return FitnessClassification.Good;
            if (vo2Max >= 32)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 30)
                return FitnessClassification.Average;
            if (vo2Max >= 26)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder55Classification(double vo2Max)
        {
            if (vo2Max > 45)
                return FitnessClassification.Excellent;
            if (vo2Max >= 39)
                return FitnessClassification.Good;
            if (vo2Max >= 36)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 32)
                return FitnessClassification.Average;
            if (vo2Max >= 29)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 25 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder45Classification(double vo2Max)
        {
            if (vo2Max > 51)
                return FitnessClassification.Excellent;
            if (vo2Max >= 43)
                return FitnessClassification.Good;
            if (vo2Max >= 39)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 35)
                return FitnessClassification.Average;
            if (vo2Max >= 31)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder35Classification(double vo2Max)
        {
            if (vo2Max > 56)
                return FitnessClassification.Excellent;
            if (vo2Max >= 49)
                return FitnessClassification.Good;
            if (vo2Max >= 43)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 40)
                return FitnessClassification.Average;
            if (vo2Max >= 35)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder25Classification(double vo2Max)
        {
            if (vo2Max > 60)
                return FitnessClassification.Excellent;
            if (vo2Max >= 52)
                return FitnessClassification.Good;
            if (vo2Max >= 47)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 42)
                return FitnessClassification.Average;
            if (vo2Max >= 37)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleOver65Classification(double vo2Max)
        {
            if (vo2Max > 32)
                return FitnessClassification.Excellent;
            if (vo2Max >= 28)
                return FitnessClassification.Good;
            if (vo2Max >= 25)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 22)
                return FitnessClassification.Average;
            if (vo2Max >= 19)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 17 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder65Classification(double vo2Max)
        {
            if (vo2Max > 37)
                return FitnessClassification.Excellent;
            if (vo2Max >= 32)
                return FitnessClassification.Good;
            if (vo2Max >= 28)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 25)
                return FitnessClassification.Average;
            if (vo2Max >= 22)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 18 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder55Classification(double vo2Max)
        {
            if (vo2Max > 40)
                return FitnessClassification.Excellent;
            if (vo2Max >= 34)
                return FitnessClassification.Good;
            if (vo2Max >= 31)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 28)
                return FitnessClassification.Average;
            if (vo2Max >= 25)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder45Classification(double vo2Max)
        {
            if (vo2Max > 45)
                return FitnessClassification.Excellent;
            if (vo2Max >= 38)
                return FitnessClassification.Good;
            if (vo2Max >= 34)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 31)
                return FitnessClassification.Average;
            if (vo2Max >= 27)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder35Classification(double vo2Max)
        {
            if (vo2Max > 52)
                return FitnessClassification.Excellent;
            if (vo2Max >= 45)
                return FitnessClassification.Good;
            if (vo2Max >= 39)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 35)
                return FitnessClassification.Average;
            if (vo2Max >= 31)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder25Classification(double vo2Max)
        {
            if (vo2Max > 56)
                return FitnessClassification.Excellent;
            if (vo2Max >= 47)
                return FitnessClassification.Good;
            if (vo2Max >= 42)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 38)
                return FitnessClassification.Average;
            if (vo2Max >= 33)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 28 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }
    }
}
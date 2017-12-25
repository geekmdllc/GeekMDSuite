using System;
using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public class PooledCohortsEquation
    {
        public PooledCohortsEquation(IPatient patient, IBloodPressure bloodPressure, 
            QuantitativeLab totalCholesterol, QuantitativeLab hdlCholesterol,
            bool hypertensionTreatment = false, bool smoker = false, bool diabetic = false)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            if (bloodPressure == null) throw new ArgumentNullException(nameof(bloodPressure));
            
            _gender = patient.Gender;
            _race = patient.Race;
            _age = patient.Age;
            _systolicBloodPressure = bloodPressure.Systolic;
            _totalCholesterol = totalCholesterol.Result;
            _hdlCholesterol = hdlCholesterol.Result;
            _hypertensionTreatment = hypertensionTreatment;
            _smoker = smoker;
            _diabetic = diabetic;
        }

        public double AscvdRiskPercentOver10Years() => 100 *
            (1 - Math.Pow(BaselineSurvival, Math.Exp(SumCoefficientValueProduct - MeanSumCoefficientValueProduct)));

        private readonly IGender _gender;
        private readonly Race _race;
        private readonly int _age;
        private readonly double _totalCholesterol;
        private readonly double _hdlCholesterol;
        private readonly int _systolicBloodPressure;
        private readonly bool _hypertensionTreatment;
        private readonly bool _smoker;
        private readonly bool _diabetic;

        private double BaselineSurvival => GetBaselineSurvival();
        private double SumCoefficientValueProduct => GetSumOfCoefficientAndValueProduct();
        private double MeanSumCoefficientValueProduct => GetMeanSumCoefficentValueProduct();
                
        private double GetBaselineSurvival()
        {
            if (Gender.IsGenotypeXy(_gender))
                return _race == Race.BlackOrAfricanAmerican
                    ? BaseLineSurvival.Xy.AfricanAmerican
                    : BaseLineSurvival.Xy.NonAfricanAmerican;

            return _race == Race.BlackOrAfricanAmerican
                ? BaseLineSurvival.Xx.AfricanAmerican
                : BaseLineSurvival.Xx.NonAfricanAmerican;
        }
        
        private double GetMeanSumCoefficentValueProduct()
        {
            if (Gender.IsGenotypeXy(_gender))
                return _race == Race.BlackOrAfricanAmerican
                    ? MeanCoefficientTimesValue.Xy.AfricanAmerican
                    : MeanCoefficientTimesValue.Xy.NonAfricanAmerican;

            return _race == Race.BlackOrAfricanAmerican
                ? MeanCoefficientTimesValue.Xx.AfricanAmerican
                : MeanCoefficientTimesValue.Xx.NonAfricanAmerican;
        }

        private double GetSumOfCoefficientAndValueProduct()
        {
            if (Gender.IsGenotypeXy(_gender))
                return _race == Race.BlackOrAfricanAmerican
                    ? MaleAfricanAmericanCoefficientTimesValueSum()
                    : MaleNonAfricanAmericanCoefficientTimesValueSum();

            return _race == Race.BlackOrAfricanAmerican
                ? FemaleAfricanAmericanCoefficientTimesValueSum()
                : FemaleNonAfricanAmericanCoefficientTimesValueSum();
        }

        private double FemaleNonAfricanAmericanCoefficientTimesValueSum()
        {
            var lnAge = Ln(_age) * Coefficients.Xx.NonAfricanAmerican.Age;
            var lnAgeSquared = Square(Ln(_age)) * Coefficients.Xx.NonAfricanAmerican.AgeSquared;
            var lnTotalChol = Ln(_totalCholesterol) * Coefficients.Xx.NonAfricanAmerican.TotalCholesterol;
            var lnAgelnTotalChol = Ln(_age) * Ln(_totalCholesterol) * Coefficients.Xx.NonAfricanAmerican.AgeTimesCholesterol;
            var lnHdlC = Ln(_hdlCholesterol) * Coefficients.Xx.NonAfricanAmerican.HdlC;
            var lnAgelnHdlC = Ln(_age) * Ln(_hdlCholesterol) * Coefficients.Xx.NonAfricanAmerican.AgeTimesHdlC;
            var logSbp = Ln(_systolicBloodPressure) * (_hypertensionTreatment
                             ? Coefficients.Xx.NonAfricanAmerican.TreatedSystolicBp
                             : Coefficients.Xx.NonAfricanAmerican.UntreatedSystolicBp);
            var currentSmoker = SmokerFactor() * Coefficients.Xx.NonAfricanAmerican.CurrentSmoker;
            var logAgeCurrentSmoker = Ln(_age) * SmokerFactor() * Coefficients.Xx.NonAfricanAmerican.AgeTimesCurrentSmoker;
            var diabetes = DiabeticFactor() * Coefficients.Xx.NonAfricanAmerican.Diabetes;

            return lnAge + lnAgeSquared + lnTotalChol + lnAgelnTotalChol + lnHdlC + lnAgelnHdlC +
                   logSbp + currentSmoker + logAgeCurrentSmoker + diabetes;
        }

        private double FemaleAfricanAmericanCoefficientTimesValueSum()
        {
            var lnAge = Ln(_age) * Coefficients.Xx.AfricanAmerican.Age;
            var lnTotalChol = Ln(_totalCholesterol) * Coefficients.Xx.AfricanAmerican.TotalCholesterol;
            var lnHdlC = Ln(_hdlCholesterol) * Coefficients.Xx.AfricanAmerican.HdlC;
            var lnAgelnHdlC = Ln(_age) * Ln(_hdlCholesterol) * Coefficients.Xx.AfricanAmerican.AgeTimesHdlC;
            var logSbp = Ln(_systolicBloodPressure) * (_hypertensionTreatment
                             ? Coefficients.Xx.AfricanAmerican.TreatedSystolicBp
                             : Coefficients.Xx.AfricanAmerican.UntreatedSystolicBp);
            var logAgelogSbp = Ln(_age) * Ln(_systolicBloodPressure) * (_hypertensionTreatment
                                          ? Coefficients.Xx.AfricanAmerican.AgeTimesTreatedSystolicBp
                                          : Coefficients.Xx.AfricanAmerican.AgetimesUntreatedSystolicBp);
            var currentSmoker = SmokerFactor() * Coefficients.Xx.AfricanAmerican.CurrentSmoker;
            var diabetes = DiabeticFactor() * Coefficients.Xx.AfricanAmerican.Diabetes;

            return lnAge + lnTotalChol + lnHdlC + lnAgelnHdlC + logSbp + logAgelogSbp + currentSmoker +  diabetes;
        }

        private double MaleNonAfricanAmericanCoefficientTimesValueSum()
        {
            var lnAge = Ln(_age) * Coefficients.Xy.NonAfricanAmerican.Age;
            var lnTotalChol = Ln(_totalCholesterol) * Coefficients.Xy.NonAfricanAmerican.TotalCholesterol;
            var lnAgelnTotalChol = Ln(_age) * Ln(_totalCholesterol) * Coefficients.Xy.NonAfricanAmerican.AgeTimesTotalCholesterol;
            var lnHdlC = Ln(_hdlCholesterol) * Coefficients.Xy.NonAfricanAmerican.HdlC;
            var lnAgelnHdlC = Ln(_age) * Ln(_hdlCholesterol) * Coefficients.Xy.NonAfricanAmerican.AgeTimesHdlC;
            var logSbp = Ln(_systolicBloodPressure) * (_hypertensionTreatment
                             ? Coefficients.Xy.NonAfricanAmerican.TreatedSystolicBp
                             : Coefficients.Xy.NonAfricanAmerican.UntreatedSystolicBp);
            var currentSmoker = SmokerFactor() * Coefficients.Xy.NonAfricanAmerican.CurrentSmoker;
            var logAgeCurrentSmoker = Ln(_age) * SmokerFactor() * Coefficients.Xy.NonAfricanAmerican.AgeTimesCurrentSmoker;
            var diabetes = DiabeticFactor() * Coefficients.Xy.NonAfricanAmerican.Diabetes;

            return lnAge + lnTotalChol + lnAgelnTotalChol + lnHdlC + lnAgelnHdlC + logSbp + currentSmoker + logAgeCurrentSmoker + diabetes;
        }

        private double MaleAfricanAmericanCoefficientTimesValueSum()
        {
            var lnAge = Ln(_age) * Coefficients.Xy.AfricanAmerican.Age;
            var lnTotalChol = Ln(_totalCholesterol) * Coefficients.Xy.AfricanAmerican.TotalCholesterol;
            var lnHdlC = Ln(_hdlCholesterol) * Coefficients.Xy.AfricanAmerican.HdlC;
            var logSbp = Ln(_systolicBloodPressure) * (_hypertensionTreatment
                             ? Coefficients.Xy.AfricanAmerican.TreatedSystolicBp
                             : Coefficients.Xy.AfricanAmerican.UntreatedSystolicBp);
            var currentSmoker = SmokerFactor() * Coefficients.Xy.AfricanAmerican.CurrentSmoker;
            var diabetes = DiabeticFactor() * Coefficients.Xy.AfricanAmerican.Diabetes;

            return lnAge + lnTotalChol + lnHdlC + logSbp + currentSmoker +  diabetes;
        }
        
        private int SmokerFactor() => (_smoker ? 1 : 0);
        private int DiabeticFactor() => (_diabetic ? 1 : 0);
        private static double Ln(double value) => Math.Log(value, Math.E);
        private static double Square(double value) => Math.Pow(value, 2);
                
        private static class MeanCoefficientTimesValue
        {
            public static class Xx
            {
                public const double NonAfricanAmerican = -29.18;
                public const double AfricanAmerican = 86.61;
            }

            public static class Xy
            {
                public const double NonAfricanAmerican = 61.18;
                public const double AfricanAmerican = 19.54; 
            }
        }
        
        private static class BaseLineSurvival
        {
            public static class Xy
            {
                public const double NonAfricanAmerican = 0.9144;
                public const double AfricanAmerican = 0.8954;
            }

            public static class Xx
            {
                public const double NonAfricanAmerican = 0.9665;
                public const double AfricanAmerican = 0.9533;   
            }
        }
        
        private static class Coefficients
        {
            public static class Xy
            {
                public static class NonAfricanAmerican
                {
                    public const double Age = 12.344;
                    public const double TotalCholesterol = 11.853;
                    public const double AgeTimesTotalCholesterol = -2.664;
                    public const double HdlC = -7.990;
                    public const double AgeTimesHdlC = 1.769;
                    public const double TreatedSystolicBp = 1.797;
                    public const double UntreatedSystolicBp = 1.764;
                    public const double AgeTimesCurrentSmoker = -1.795;
                    public const double CurrentSmoker = 7.837;
                    public const double Diabetes = 0.658;
                }
            
                public static class AfricanAmerican
                {
                    public const double Age = 2.469;
                    public const double TotalCholesterol = 0.302;
                    public const double HdlC = -0.307;
                    public const double TreatedSystolicBp = 1.916;
                    public const double UntreatedSystolicBp = 1.809;
                    public const double CurrentSmoker = 0.549;
                    public const double Diabetes = 0.645;
                }
            }
            public static class Xx
            {
                public static class NonAfricanAmerican
                {
                    public const double Age = -29.799;
                    public const double AgeSquared = 4.884;
                    public const double TotalCholesterol = 13.540;
                    public const double AgeTimesCholesterol = -3.114;
                    public const double HdlC = -13.578;
                    public const double AgeTimesHdlC = 3.149;
                    public const double TreatedSystolicBp = 2.019;
                    public const double UntreatedSystolicBp = 1.957;
                    public const double AgeTimesCurrentSmoker = -1.665;
                    public const double CurrentSmoker = 7.574;
                    public const double Diabetes = 0.661;
                }
            
                public static class AfricanAmerican
                {
                    public const double Age = 17.114;
                    public const double TotalCholesterol = 0.940;
                    public const double HdlC = -18.920;
                    public const double AgeTimesHdlC = 4.475;
                    public const double TreatedSystolicBp = 29.291;
                    public const double AgeTimesTreatedSystolicBp = -6.432;
                    public const double UntreatedSystolicBp = 27.820;
                    public const double AgetimesUntreatedSystolicBp = -6.087;
                    public const double CurrentSmoker = 0.691;
                    public const double Diabetes = 0.874;
                }
            }
        }
    }
}
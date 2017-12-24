using System;

namespace GeekMDSuite.Tools.Cardiology
{
    public class PooledCohortsEquation
    {
        public PooledCohortsEquation(IPatient patient, BloodPressure bloodPressure, int totalCholesterol, int hdlCholesterol,
            bool hypertensionTreatment = false, bool smoker = false, bool diabetic = false)
        {
            _gender = patient.Gender;
            _race = patient.Race;
            _age = patient.Age;
            _systolicBloodPressure = bloodPressure.Systolic;
            _totalCholesterol = totalCholesterol;
            _hdlCholesterol = hdlCholesterol;
            _hypertensionTreatment = hypertensionTreatment;
            _smoker = smoker;
            _diabetic = diabetic;
        }
        
        public double Calculate() => 1 - (Math.Pow(GetBaselineSurvival(),
                Math.Exp(CoefficientTimesValueSum() - MeanCoefficientTimesValueSum())));

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
        
        private double MeanCoefficientTimesValueSum()
        {
            if (Gender.IsGenotypeXy(_gender))
                return _race == Race.BlackOrAfricanAmerican 
                    ? MeanCoefficientTimesValue.Xy.AfricanAmerican 
                    : MeanCoefficientTimesValue.Xy.NonAfricanAmerican;

            return _race == Race.BlackOrAfricanAmerican
                ? MeanCoefficientTimesValue.Xx.AfricanAmerican
                : MeanCoefficientTimesValue.Xx.NonAfricanAmerican;
        }
        
        private double CoefficientTimesValueSum()
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
            var lnAge = Ln(_age) * Coefficients.Xx.NonAfricanAmerican.Ln.Age;
            var lnAgeSquared = Square(Ln(_age)) * Coefficients.Xx.NonAfricanAmerican.Ln.AgeSquared;
            var lnTotalChol = Ln(_totalCholesterol) * Coefficients.Xx.NonAfricanAmerican.Ln.TotalCholesterol;
            var lnAgelnTotalChol = Ln(_age) * Ln(_totalCholesterol) * Coefficients.Xx.NonAfricanAmerican.Ln.AgeTimesCholesterol;
            var lnHdlC = Ln(_hdlCholesterol) * Coefficients.Xx.NonAfricanAmerican.Ln.HdlC;
            var lnAgelnHdlC = Ln(_age) * Ln(_hdlCholesterol) * Coefficients.Xx.NonAfricanAmerican.Ln.AgeTimesHdlC;
            var logTreatedSbp = Log(_systolicBloodPressure) * Coefficients.Xx.NonAfricanAmerican.Log.TreatedSystolicBp;
            var logUntreatedSbp = Log(_systolicBloodPressure) * Coefficients.Xx.NonAfricanAmerican.Log.UntreatedSystolicBp;
            var currentSmoker = (_smoker ? 7.574 : 0) * Coefficients.Xx.NonAfricanAmerican.Normal.CurrentSmoker;
            var logAgeCurrentSmoker = Log(_age) * (_smoker ? 7.574 : 0) * Coefficients.Xx.NonAfricanAmerican.Log.AgeTimesCurrentSmoker;
            var diabetes = (_diabetic ? 0.661 : 0) * Coefficients.Xx.NonAfricanAmerican.Normal.Diabetes;

            var sbp = _hypertensionTreatment ?  logTreatedSbp : logUntreatedSbp;

            var sum = lnAge + lnAgeSquared + lnTotalChol + lnAgelnTotalChol + lnHdlC + lnAgelnHdlC +
                   sbp + currentSmoker + logAgeCurrentSmoker + diabetes;

            return sum;
        }
        private double MaleNonAfricanAmericanCoefficientTimesValueSum() => throw new NotImplementedException();
        private double MaleAfricanAmericanCoefficientTimesValueSum() => throw new NotImplementedException();
        private double FemaleAfricanAmericanCoefficientTimesValueSum() => throw new NotImplementedException();

        private double Ln(double value) => Math.Log(value, Math.E);
        private double Square(double value) => Math.Pow(value, 2);
        private double Log(double value) => Math.Log10(value);
        
        private static class MeanCoefficientTimesValue
        {
            public static class Xy
            {
                public const double NonAfricanAmerican = -29.18;
                public const double AfricanAmerican = 86.16;
            }

            public static class Xx
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
                    public static class Log
                    {
                        public const double Age = 12.344;
                        public const double TotalCholesterol = 11.853;
                        public const double AgeTimesTotalCholesterol = -2.664;
                        public const double HdlC = -7.990;
                        public const double AgeTimesHdlC = 1.769;
                        public const double TreatedSystolicBp = 1.797;
                        public const double UntreatedSystolicBp = 1.764;
                        public const double AgeTimesCurrentSmoker = 7.837;
                    }

                    public static class Normal
                    {
                        public const double CurrentSmoker = 7.837;
                        public const double Diabetes = 0.658;
                    }
                }
            
                public static class AfricanAmerican
                {
                    public static class Log
                    {
                        public const double Age = 2.469;
                        public const double TotalCholesterol = 0.302;
                        public const double AgeTimesTotalCholesterol = 1; // not applicable
                        public const double HdlC = -0.307;
                        public const double AgeTimesHdlC = 1; // not applicable
                        public const double TreatedSystolicBp = 1.916;
                        public const double UntreatedSystolicBp = 1.809;
                        public const double AgeTimesCurrentSmoker = 1; // not applicable
                    }

                    public static class Normal
                    {
                        public const double CurrentSmoker = 0.549;
                        public const double Diabetes = 0.645;
                    }
                }
            }
            public static class Xx
            {
                public static class NonAfricanAmerican
                {
                    public static class Ln
                    {
                        public const double Age = -29.799;
                        public const double AgeSquared = 4.884;
                        public const double TotalCholesterol = 13.540;
                        public const double AgeTimesCholesterol = -3.114;
                        public const double HdlC = -13.578;
                        public const double AgeTimesHdlC = 3.149;
                    }

                    public static class Log
                    {
                        public const double TreatedSystolicBp = 2.019;
                        public const double AgeTimesTreatedSystolicBp = 1; // not applicable
                        public const double UntreatedSystolicBp = 1.957;
                        public const double AgetimesUntreatedSystolicBp = 1; // not applicable
                        
                        public const double AgeTimesCurrentSmoker = -1.665;
                    }

                    public static class Normal
                    {
                        public const double CurrentSmoker = 7.574;
                        public const double Diabetes = 0.661;
                    }
                }
            
                public static class AfricanAmerican
                {
                    public static class Ln
                    {
                        public const double Age = 17.114;
                        public const double AgeSquared = 1; //not applicable
                        public const double TotalCholesterol = 0.940;
                        public const double AgeTimesCholesterol = 1; // not applicable
                        public const double HdlC = -18.920;
                        public const double AgeTimesHdlC = 4.475;
                    }

                    public static class Log
                    {
                        public const double TreatedSystolicBp = 29.291;
                        public const double AgeTimesTreatedSystolicBp = -6.432;
                        public const double UntreatedSystolicBp = 27.820;
                        public const double AgetimesUntreatedSystolicBp = -6.087;
                        public const double AgeTimesCurrentSmoker = 1; // not applicable
                    }

                    public static class Normal
                    {
                        public const double CurrentSmoker = 0.691;
                        public const double Diabetes = 0.874;
                    }
                }
            }
        }
                
        private readonly IGender _gender;
        private readonly Race _race;
        private int _age;
        private int _totalCholesterol;
        private int _hdlCholesterol;
        private int _systolicBloodPressure;
        private bool _hypertensionTreatment;
        private bool _smoker;
        private bool _diabetic;

    }
}
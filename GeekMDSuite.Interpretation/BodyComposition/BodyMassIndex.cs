using System;
using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation.BodyComposition
{
    public class BodyMassIndex
    {
        public BodyMassIndex(IPatient patient)
        {
            _weightKilograms = patient.BodyWeight.Kilograms;
            _heightMeters = patient.Height.Meters;
            _race = patient.Race;
        }

        public BodyMassIndexCategory Classification => ClassifyBodyMassIndex();
        
        public double Value => 
            _weightKilograms / Math.Pow(_heightMeters, 2);

        public static double UnderWeightLowerLimit = 17.5;
        public static double NormalWeightLowerLimit = 18.5;
        public static double OverWeightLowerLimitAsian = 23;
        public static double OverWeightLowerLimitNonAsian = 25;
        public static double ObeseClass1LowerLimitAsian = 27;
        public static double ObeseClass1LowerLimitNonAsian = 30;
        public static double ObeseClass2LowerLimit = 35;
        public static double ObeseClass3LowerLimit = 40;
        
        private double _weightKilograms;
        private double _heightMeters;
        private Race _race;
        
        private BodyMassIndexCategory ClassifyBodyMassIndex()
        {
            var overWeightLowerLimit = _race == Race.Asian 
                ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;
            var obeseClass1LowerLimit = _race == Race.Asian 
                ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
            
            if (Value < UnderWeightLowerLimit)
                return BodyMassIndexCategory.SeverelyUnderweight;
            if (Value < NormalWeightLowerLimit)
                return BodyMassIndexCategory.Underweight;
            if (Value < overWeightLowerLimit)
                return BodyMassIndexCategory.NormalWeight;
            if (Value < obeseClass1LowerLimit)
                return BodyMassIndexCategory.OverWeight;
            if (Value < ObeseClass2LowerLimit)
                return BodyMassIndexCategory.ObesityClass1;
            return Value < ObeseClass3LowerLimit ? BodyMassIndexCategory.ObesityClass2 : BodyMassIndexCategory.ObesityClass3;
        }
        
    }
}
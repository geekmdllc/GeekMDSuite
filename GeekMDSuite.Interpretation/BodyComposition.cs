using GeekMDSuite.Common;
using Calc = GeekMDSuite.Calculations.BodyComposition;

namespace GeekMDSuite.Interpretation
{
    public class BodyComposition
    {
        public PhysicalCharacteristics PhysicalCharacteristics { get; set;  }
        public double VisceralFatArea { get; set; }
        public double PercentBodyFat { get; set; }

        public BodyComposition (
                        PhysicalCharacteristics physicalCharacteristics, 
                        double visceralFatArea, 
                        double percentBodyFat)
        {
            PhysicalCharacteristics = physicalCharacteristics;
            VisceralFatArea = visceralFatArea;
            PercentBodyFat = percentBodyFat;
        }

        // Percent Body Fat

        private double AthleticBodyFatLowerLimit => PhysicalCharacteristics.IsXy
            ? AthleticBodyFatLowerLimitMale
            : AthleticBodyFatLowerLimitFemale;

        private double FitnessBodyFatLowerLimit => PhysicalCharacteristics.IsXy
            ? FitnessBodyFatLowerLimitMale
            : FitnessBodyFatLowerLimitFemale;

        private double AcceptableBodyFatLowerLimit => PhysicalCharacteristics.IsXy
            ? AcceptableBodyFatLowerLimitMale
            : AcceptableBodyFatLowerLimitFemale;

        private double OverFatLowerLimit => PhysicalCharacteristics.IsXy
            ? OverFatLowerLimitMale
            : OverFatLowerLimitFemale;
        
        public BodyFatFlag BodyFatFlag {
            get
            {
                if (PercentBodyFat < AthleticBodyFatLowerLimit) 
                    return BodyFatFlag.UnderFat;
                if (PercentBodyFat < FitnessBodyFatLowerLimit) 
                    return BodyFatFlag.Athletic;
                if (PercentBodyFat < AcceptableBodyFatLowerLimit) 
                    return BodyFatFlag.Fitness;
                return PercentBodyFat < OverFatLowerLimit ? 
                    BodyFatFlag.Acceptable : BodyFatFlag.OverFat;
            }
        }

        // Body mass Index - Adjust for Race
        
        public BodyMassIndexClassification BmiFlag => ClassifyBodyMassIndex();

        private BodyMassIndexClassification ClassifyBodyMassIndex()
        {
            var OverWeightLowerLimit =
            PhysicalCharacteristics.Race == Race.Asian ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;

            var ObeseClass1LowerLimit =
            PhysicalCharacteristics.Race == Race.Asian ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
        
            var BodyMassIndex = Calc.BodyMassIndexCalculator(
            PhysicalCharacteristics.Weight.Pounds, 
            PhysicalCharacteristics.Height.Inches);
            
            if (BodyMassIndex < UnderWeightLowerLimit)
                return BodyMassIndexClassification.SeverelyUnderweight;
            if (BodyMassIndex < NormalWeightLowerLimit)
                return BodyMassIndexClassification.Underweight;
            if (BodyMassIndex < OverWeightLowerLimit)
                return BodyMassIndexClassification.NormalWeight;
            if (BodyMassIndex < ObeseClass1LowerLimit)
                return BodyMassIndexClassification.OverWeight;
            if (BodyMassIndex < ObeseClass2LowerLimit)
                return BodyMassIndexClassification.ObesityClassI;
            return BodyMassIndex < ObeseClass3LowerLimit
                ? BodyMassIndexClassification.ObesityClassII
                : BodyMassIndexClassification.ObesityClassIII;
        }

        
        
        // Visceral Fat
        
        public VisceralFatClassification VisceralFatFlag => ClassifyVisceralFat();
        
        private VisceralFatClassification ClassifyVisceralFat()
        {
            if (VisceralFatArea > VisceralFatAreaUpperLimit * 1.5)
                return VisceralFatClassification.VeryElevated;
            if (VisceralFatArea > VisceralFatAreaUpperLimit)
                return VisceralFatClassification.Elevated;
            return VisceralFatArea > VisceralFatAreaUpperLimit * 0.5
                ? VisceralFatClassification.Acceptable
                : VisceralFatClassification.Excellent;
        }

        // BMI Static Members
        
        public static double UnderWeightLowerLimit = 17.5;
        public static double NormalWeightLowerLimit = 18.5;
        public static double OverWeightLowerLimitAsian = 23;
        public static double OverWeightLowerLimitNonAsian = 25;
        public static double ObeseClass1LowerLimitAsian = 27;
        public static double ObeseClass1LowerLimitNonAsian = 30;
        public static double ObeseClass2LowerLimit = 35;
        public static double ObeseClass3LowerLimit = 40;
        
        // Waist to Height Static Members
        
        public static double SlimWaistToHeightLowerLimitMale = 0.34;
        public static double SlimWaistToHeightLowerLimitFemale = 0.34;
        public static double HealthyWaistToHeightLowerLimitMale = 0.43;
        public static double HealthyWaistToHeightLowerLimitFemale = 0.42;
        public static double OverweightWaistToHeightLowerLimitMale = 0.53;
        public static double OverweightWaistToHeightLowerLimitFemale = 0.49;
        public static double VeryOverweightWaistToHeightLowerLimitMale = 0.58;
        public static double VeryOverweightWaistToHeightLowerLimitFemale = 0.54;
        public static double MorbidlyObeseWaistToHeightLowerLimitMale = 0.63;
        public static double MorbidlyObeseWaistToHeightLowerLimitFemale = 0.58;
        
        // Body Fat Static Members
        
        public double AthleticBodyFatLowerLimitMale = 6;
        public double AthleticBodyFatLowerLimitFemale = 14;
        public double FitnessBodyFatLowerLimitMale = 14;
        public double FitnessBodyFatLowerLimitFemale = 21;
        public double AcceptableBodyFatLowerLimitMale = 18;
        public double AcceptableBodyFatLowerLimitFemale = 25;
        public double OverFatLowerLimitMale = 25;
        public double OverFatLowerLimitFemale = 32;
        
        // Visceral Fat Static Members
        
        public double VisceralFatAreaUpperLimit = 100;        
    }
}
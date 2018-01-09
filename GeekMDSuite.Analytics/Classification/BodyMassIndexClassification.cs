using System;
using GeekMDSuite.Analytics.Tools.BodyComposition;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyMassIndexClassification : IClassifiable<BodyMassIndex>
    {
        private readonly BodyComposition _bodyComposition;
        private readonly Patient _patient;

        public BodyMassIndexClassification( BodyCompositionClassificationParameters parameters)
        {
            _patient = parameters.Patient ?? throw new ArgumentNullException(nameof(parameters.Patient));
            _bodyComposition = parameters.BodyComposition ?? throw new ArgumentNullException(nameof(parameters.BodyComposition));
        }

        public BodyMassIndex Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private BodyMassIndex Classify()
        {
            var bmi = CalculateBodyMassIndex.Calculate(_bodyComposition.Weight.Kilograms,
                _bodyComposition.Height.Meters);
            var overWeightLowerLimit = _patient.Race == Race.Asian
                ? LowerLimits.Overweight.Asian
                : LowerLimits.Overweight.NonAsian;
            var obeseClass1LowerLimit = _patient.Race == Race.Asian
                ? LowerLimits.ObeseClass1.Asian
                : LowerLimits.ObeseClass1.NonAsian;

            if (bmi < LowerLimits.UnderWeight) return BodyMassIndex.SeverelyUnderweight;
            if (bmi < LowerLimits.NormalWeight) return BodyMassIndex.Underweight;
            if (bmi < overWeightLowerLimit) return BodyMassIndex.NormalWeight;
            if (bmi < obeseClass1LowerLimit) return BodyMassIndex.OverWeight;
            if (bmi < LowerLimits.ObeseClass2) return BodyMassIndex.ObesityClass1;
            return bmi < LowerLimits.ObeseClass3
                ? BodyMassIndex.ObesityClass2
                : BodyMassIndex.ObesityClass3;
        }

        public static class LowerLimits
        {
            public const double UnderWeight = 17.5;
            public const double NormalWeight = 18.5;
            public const double ObeseClass2 = 35;
            public const double ObeseClass3 = 40;

            public static class Overweight
            {
                public const double Asian = 23;
                public const double NonAsian = 25;
            }

            public static class ObeseClass1
            {
                public const double Asian = 27;
                public const double NonAsian = 30;
            }
        }
    }
}
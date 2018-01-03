﻿using System;
using GeekMDSuite.Core;

namespace GeekMDSuite.Analytics.Classification
{
    public class VisceralFatClassification : IClassifiable<VisceralFat>
    {
        public VisceralFatClassification(BodyCompositionExpanded bodyCompositionExpanded)
        {
            if (bodyCompositionExpanded == null) throw new ArgumentNullException(nameof(bodyCompositionExpanded));
            _visceralFat = bodyCompositionExpanded.VisceralFat;
        }
        
        public VisceralFat Classification => Classify();

        public static class LowerLimits
        {
            public const double Excellent = 0;
            public const double Acceptable = 50;
            public const double Elevated = 100;
            public const double VeryElevated = 150;
        }

        public override string ToString() => Classification.ToString();

        private readonly double _visceralFat;
        
        private VisceralFat Classify()
        {           
            if (_visceralFat >= LowerLimits.VeryElevated)
                return VisceralFat.VeryElevated;
            if (_visceralFat >= LowerLimits.Elevated)
                return VisceralFat.Elevated;
            return _visceralFat > LowerLimits.Acceptable
                ? VisceralFat.Acceptable
                : VisceralFat.Excellent;
        }
    }
}
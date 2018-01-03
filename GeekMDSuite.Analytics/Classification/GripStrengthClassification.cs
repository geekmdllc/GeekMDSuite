using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthClassification : IClassifiable<GripStrengthClassificationResult>, IGripStrengthLimits
    {

        public GripStrengthClassification(IGripStrength gripStrength, Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            _gripStrength = gripStrength;
            _ranges = GripStrengthRepository.GetRanges(patient);
        }

        public GripStrengthClassificationResult Classification => Classify();

        public IMassMeasurement LowerLimitOfNormal => _ranges.LowerLimitOfNormal;
        public IMassMeasurement UpperLimitOfNormal => _ranges.UpperLimitOfNormal;

        public override string ToString() => Classification.ToString();

        private readonly IGripStrength _gripStrength;
        private readonly GripStrengthLimits _ranges;

        private GripStrengthClassificationResult Classify() => 
            GripStrengthClassificationResult.Create(ClassifyLeft(), ClassifyRight());

        private GripStrengthScore ClassifyRight() => ClassifySide(_gripStrength.Right);

        private GripStrengthScore ClassifyLeft() => ClassifySide(_gripStrength.Left);

        private GripStrengthScore ClassifySide(IMassMeasurement gripStrength)
        {
            if(gripStrength.Kilograms < LowerLimitOfNormal.Kilograms) 
                return GripStrengthScore.Weak;
            if (gripStrength.Kilograms >= LowerLimitOfNormal.Kilograms &&
                gripStrength.Kilograms <= UpperLimitOfNormal.Kilograms) 
                return GripStrengthScore.Normal;
            return gripStrength.Kilograms > UpperLimitOfNormal.Kilograms
                ? GripStrengthScore.Strong 
                : throw new ArgumentOutOfRangeException(nameof(gripStrength));
        }
    }
}
using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Utilities.MeasurementUnits;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthClassification : IClassifiable<GripStrengthClassificationResult>
    {
        private readonly GripStrength _gripStrength;
        private readonly GripStrengthLimits _ranges;

        public GripStrengthClassification(GripStrength gripStrength, Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            _gripStrength = gripStrength ?? throw new ArgumentNullException(nameof(gripStrength));
            _ranges = GripStrengthRepository.GetRanges(patient);
        }

        public MassMeasurement LowerLimitOfNormal => _ranges.LowerLimitOfNormal;
        public MassMeasurement UpperLimitOfNormal => _ranges.UpperLimitOfNormal;

        public GripStrengthClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private GripStrengthClassificationResult Classify()
        {
            return GripStrengthClassificationResult.Create(ClassifyLeft(), ClassifyRight());
        }

        private GripStrengthScore ClassifyRight()
        {
            return ClassifySide(_gripStrength.Right);
        }

        private GripStrengthScore ClassifyLeft()
        {
            return ClassifySide(_gripStrength.Left);
        }

        private GripStrengthScore ClassifySide(MassMeasurement gripStrength)
        {
            if (gripStrength.Kilograms < LowerLimitOfNormal.Kilograms)
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
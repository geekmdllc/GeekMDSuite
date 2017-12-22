using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Repositories;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public class GripStrengthInterpretation : IInterpretable<GripStrengthClassificationResult>, IGripStrengthLimits
    {

        public GripStrengthInterpretation(GripStrength gripStrength, IPatient patient)
        {
            _gripStrength = gripStrength;
            _ranges = GripStrengthRepository.GetRanges(patient);
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public GripStrengthClassificationResult Classification => Classify();

        public IMassMeasurement LowerLimitOfNormal => _ranges.LowerLimitOfNormal;
        public IMassMeasurement UpperLimitOfNormal => _ranges.UpperLimitOfNormal;

        public override string ToString() => Classification.ToString();

        private readonly GripStrength _gripStrength;
        private readonly GripStrengthLimits _ranges;

        private GripStrengthClassificationResult Classify() => 
            GripStrengthClassificationResult.Create(ClassifyLeft(), ClassifyRight());

        private GripStrengthClassification ClassifyRight() => ClassifySide(_gripStrength.Right);

        private GripStrengthClassification ClassifyLeft() => ClassifySide(_gripStrength.Left);

        private GripStrengthClassification ClassifySide(IMassMeasurement gripStrength)
        {
            if(gripStrength.Kilograms < LowerLimitOfNormal.Kilograms) 
                return GripStrengthClassification.Weak;
            if (gripStrength.Kilograms >= LowerLimitOfNormal.Kilograms &&
                gripStrength.Kilograms <= UpperLimitOfNormal.Kilograms) 
                return GripStrengthClassification.Normal;
            return gripStrength.Kilograms > UpperLimitOfNormal.Kilograms
                ? GripStrengthClassification.Strong 
                : throw new ArgumentOutOfRangeException(nameof(gripStrength));
        }
    }
}
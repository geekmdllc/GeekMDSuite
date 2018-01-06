using System;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionExpandedClassification : BodyCompositionBaseClassification,
        IClassifiable<BodyCompositionClassificationResult>
    {
        private readonly BodyCompositionExpanded _bodyCompositionExpanded;
        private readonly Patient _patient;

        public BodyCompositionExpandedClassification(
            BodyCompositionExpanded bodyCompositionExpanded, Patient patient)
            : base(bodyCompositionExpanded, patient)
        {
            _bodyCompositionExpanded = bodyCompositionExpanded ??
                                       throw new ArgumentNullException(nameof(bodyCompositionExpanded));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatClassification(_bodyCompositionExpanded, _patient).Classification;

        public VisceralFat VisceralFat =>
            new VisceralFatClassification(_bodyCompositionExpanded).Classification;

        public BodyCompositionClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        protected override BodyCompositionClassificationResult Classify()
        {
            if (ThinAndLean())
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.ThinAndLean);
            if (MuscularAndLean())
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.MuscularAndLean);
            if (SkinnyFat())
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.SkinnyFat);
            return OverWeightButLean()
                ? BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightSuspectMuscular)
                : BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightOverFat);
        }

        private bool MuscularAndLean()
        {
            return BmiIsOverweightOrHigher() && BodyFatIsLean() && VisceralFatIsLean();
        }

        protected override bool ThinAndLean()
        {
            return BodyFatIsLean() && VisceralFatIsLean() && base.ThinAndLean();
        }

        private bool BodyFatIsLean()
        {
            return PercentBodyFat == PercentBodyFat.Fitness ||
                   PercentBodyFat == PercentBodyFat.Athletic ||
                   PercentBodyFat == PercentBodyFat.UnderFat;
        }

        private bool VisceralFatIsLean()
        {
            return VisceralFat == VisceralFat.Excellent ||
                   VisceralFat == VisceralFat.Acceptable;
        }
    }
}
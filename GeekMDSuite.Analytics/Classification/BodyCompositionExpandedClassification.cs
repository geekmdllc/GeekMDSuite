using System;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionExpandedClassificationParameters
    {
        public BodyCompositionExpandedClassificationParameters(BodyCompositionExpanded bodyCompositionExpanded, Patient patient)
        {
            BodyCompositionExpanded = bodyCompositionExpanded;
            Patient = patient;
        }

        public BodyCompositionExpanded BodyCompositionExpanded { get; private set; }
        public Patient Patient { get; private set; }
    }

    public class BodyCompositionExpandedClassification : BodyCompositionBaseClassification,
        IClassifiable<BodyCompositionClassificationResult>
    {
        public BodyCompositionExpandedClassification(BodyCompositionExpandedClassificationParameters bodyCompositionExpandedClassificationParameters)
            : base(bodyCompositionExpandedClassificationParameters.BodyCompositionExpanded, bodyCompositionExpandedClassificationParameters.Patient)
        {
            _bodyCompositionExpanded = bodyCompositionExpandedClassificationParameters.BodyCompositionExpanded ??
                                       throw new ArgumentNullException(nameof(bodyCompositionExpandedClassificationParameters.BodyCompositionExpanded));
            _patient = bodyCompositionExpandedClassificationParameters.Patient ?? throw new ArgumentNullException(nameof(bodyCompositionExpandedClassificationParameters.Patient));
        }

        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatClassification(new BodyCompositionExpandedClassificationParameters(_bodyCompositionExpanded, _patient)).Classification;

        public VisceralFat VisceralFat =>
            new VisceralFatClassification(_bodyCompositionExpanded).Classification;

        public BodyCompositionClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }
        
        private readonly BodyCompositionExpanded _bodyCompositionExpanded;
        private readonly Patient _patient;


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
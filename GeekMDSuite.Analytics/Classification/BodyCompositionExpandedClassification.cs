using System;
using GeekMDSuite.Core;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyCompositionExpandedClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionClassificationResult>
    {
        public BodyCompositionExpandedClassification( 
            BodyCompositionExpanded bodyCompositionExpanded, Patient patient) 
            : base(bodyCompositionExpanded, patient)
        {
            _bodyCompositionExpanded = bodyCompositionExpanded ?? throw new ArgumentNullException(nameof(bodyCompositionExpanded));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public BodyCompositionClassificationResult Classification => Classify();
        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatClassification(_bodyCompositionExpanded, _patient).Classification;
        public VisceralFat VisceralFat =>
            new VisceralFatClassification(_bodyCompositionExpanded).Classification;

        public override string ToString() => Classification.ToString();
        
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

        protected bool MuscularAndLean() => BmiIsOverweightOrHigher() && BodyFatIsLean() && VisceralFatIsLean();

        protected override bool ThinAndLean() => BodyFatIsLean() && VisceralFatIsLean() && base.ThinAndLean();

        protected bool BodyFatIsLean() => PercentBodyFat == PercentBodyFat.Fitness ||
                                          PercentBodyFat == PercentBodyFat.Athletic ||
                                          PercentBodyFat == PercentBodyFat.UnderFat;

        protected bool VisceralFatIsLean() => VisceralFat == VisceralFat.Excellent || 
                                              VisceralFat == VisceralFat.Acceptable;
    }
}
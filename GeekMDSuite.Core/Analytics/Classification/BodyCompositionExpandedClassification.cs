using System;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class BodyCompositionExpandedClassification : BodyCompositionBaseClassification, IClassifiable<BodyCompositionResult>
    {
        public BodyCompositionExpandedClassification( 
            IBodyCompositionExpanded bodyCompositionExpanded, IPatient patient) 
            : base(bodyCompositionExpanded, patient)
        {
            _bodyCompositionExpanded = bodyCompositionExpanded ?? throw new ArgumentNullException(nameof(bodyCompositionExpanded));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public BodyCompositionResult Classification => Classify();
        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatClassification(_bodyCompositionExpanded, _patient).Classification;
        public VisceralFat VisceralFat =>
            new VisceralFatClassification(_bodyCompositionExpanded).Classification;

        public override string ToString() => Classification.ToString();
        
        private readonly IBodyCompositionExpanded _bodyCompositionExpanded;
        private readonly IPatient _patient;

        protected override BodyCompositionResult Classify()
        {
            if (ThinAndLean())
                return BodyCompositionResult.ThinAndLean;
            if (MuscularAndLean())
                return BodyCompositionResult.MuscularAndLean;
            if (SkinnyFat()) 
                return BodyCompositionResult.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionResult.OverweightSuspectMuscular 
                : BodyCompositionResult.OverweightOverFat;
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
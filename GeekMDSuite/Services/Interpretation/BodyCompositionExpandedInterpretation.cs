using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyCompositionExpandedInterpretation : BodyCompositionBaseInterpretation, IInterpretable<BodyCompositionClassification>
    {
        public BodyCompositionExpandedInterpretation( 
            IBodyCompositionExpanded bodyCompositionExpanded, IPatient patient) 
            : base(bodyCompositionExpanded, patient)
        {
            _bodyCompositionExpanded = bodyCompositionExpanded;
            _patient = patient;
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public BodyCompositionClassification Classification => Classify();
        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatInterpretation(_bodyCompositionExpanded, _patient).Classification;
        public VisceralFat VisceralFat =>
            new VisceralFatInterpretation(_bodyCompositionExpanded).Classification;

        public override string ToString() => Classification.ToString();
        
        private readonly IBodyCompositionExpanded _bodyCompositionExpanded;
        private readonly IPatient _patient;

        protected override BodyCompositionClassification Classify()
        {
            if (ThinAndLean())
                return BodyCompositionClassification.ThinAndLean;
            if (MuscularAndLean())
                return BodyCompositionClassification.MuscularAndLean;
            if (SkinnyFat()) 
                return BodyCompositionClassification.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionClassification.OverweightSuspectMuscular 
                : BodyCompositionClassification.OverweightOverFat;
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
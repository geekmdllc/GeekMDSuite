namespace GeekMDSuite.Core.Analytics.Classification
{
    public class QuantitativeLabClassificationModel : IQuantitativeLabInterpretationModel
    {
        public string LabName { get; set; }
        public string LabNameFull { get; set; }
        public string LabNameShort { get; set; }
        public string Specimen  { get; set; }
        public double UsToSiConversionFactor { get; set; }
        public double LowerBound  { get; set; }
        public double LowerLimitOfLowFemale  { get; set; }
        public double LowerLimitOfLowMale { get; set; }
        public double LowerLimitOfNormalFemale  { get; set; }
        public double LowerLimitOfNormalMale  { get; set; }
        public double UpperLimitOfNormalFemale  { get; set; }
        public double UpperLimitOfNormalMale  { get; set; }
        public double UpperLimitOfBorderlineFemale  { get; set; }
        public double UpperLimitOfBorderlineMale  { get; set; }
        public double UpperLimitOfHighFemale  { get; set; }
        public double UpperLimitOfHighMale  { get; set; }
        public double UpperBound  { get; set; }
        public string UnitsSI  { get; set; }
        public string UnitsUS  { get; set; }
        public string Interpretation { get; set; }
        public string Comments { get; set; }

        public override string ToString() => $"{LabNameShort} ({Specimen})";
    }
}
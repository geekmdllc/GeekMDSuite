namespace GeekMDSuite.Analytics.Classification
{
    public interface IQuantitativeLabInterpretationModel
    {
        string LabName { get; set; }
        string LabNameFull { get; set; }
        string LabNameShort { get; set; }
        string Specimen { get; set; }
        double UsToSiConversionFactor { get; set; }
        double LowerBound { get; set; }
        double LowerLimitOfLowFemale { get; set; }
        double LowerLimitOfLowMale { get; set; }
        double LowerLimitOfNormalFemale { get; set; }
        double LowerLimitOfNormalMale { get; set; }
        double UpperLimitOfNormalFemale { get; set; }
        double UpperLimitOfNormalMale { get; set; }
        double UpperLimitOfBorderlineFemale { get; set; }
        double UpperLimitOfBorderlineMale { get; set; }
        double UpperLimitOfHighFemale { get; set; }
        double UpperLimitOfHighMale { get; set; }
        double UpperBound { get; set; }
        string UnitsSI { get; set; }
        string UnitsUS { get; set; }
        string Interpretation { get; set; }
        string Comments { get; set; }
    }
}
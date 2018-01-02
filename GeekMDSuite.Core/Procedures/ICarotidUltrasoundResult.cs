namespace GeekMDSuite.Core.Procedures
{
    public interface ICarotidUltrasoundResult
    {
        double IntimaMediaMeasurementMillimeters { get; set; }
        CarotidIntimaMediaThicknessGrade Grade { get; set; }
        CarotidPlaqueCharacter Character { get; set; }
        CarotidPercentStenosisGrade Stenosis { get; set; }
    }
}
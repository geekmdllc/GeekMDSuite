namespace GeekMDSuite.Procedures
{
    public interface ICarotidUltrasoundResult
    {
        double IntimaMediaMeasurementMillimeters { get; }
        CarotidIntimaMediaThicknessGrade Grade { get; }
        CarotidPlaqueCharacter Character { get; }
        CarotidPercentStenosisGrade Stenosis { get; }
    }
}
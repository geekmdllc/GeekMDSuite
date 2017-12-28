namespace GeekMDSuite.LaboratoryData
{
    public interface IQuantitativeLab
    {
        double Result { get; }
        QuantitativeLabType Type { get; }
        MeasurementSystem MeasurementSystem { get; }
    }
}
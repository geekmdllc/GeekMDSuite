namespace GeekMDSuite.Core.LaboratoryData
{
    public interface IQuantitativeLab
    {
        double Result { get; set; }
        QuantitativeLabType Type { get; set; }
        MeasurementSystem MeasurementSystem { get; set; }
    }
}
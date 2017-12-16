namespace GeekMDSuite.LaboratoryData
{
    public abstract class QuantitativeLab
    {

        public QuantitativeLab(double result, QuantitativeLabType type, MeasurementSystem measurementSystem)
        {
            Result = result;
            Type = type;
            MeasurementSystem = measurementSystem;
        }
        public double Result { get; }
        public QuantitativeLabType Type { get; }
        public MeasurementSystem MeasurementSystem { get; }
        
    }

    public sealed class TestosteroneTotalSerum : QuantitativeLab
    {
        public TestosteroneTotalSerum(double result, MeasurementSystem measurementSystem) 
            : base(result, QuantitativeLabType.Testosterone_Total_Serum, measurementSystem)
        {
        }
    }
}
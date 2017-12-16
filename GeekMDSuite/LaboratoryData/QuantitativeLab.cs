namespace GeekMDSuite.LaboratoryData
{
    public partial class QuantitativeLab
    {

        internal QuantitativeLab(double result, QuantitativeLabType type, MeasurementSystem measurementSystem = MeasurementSystem.TraditionalUS)
        {
            Result = result;
            Type = type;
            MeasurementSystem = measurementSystem;
        }
        public double Result { get; }
        public QuantitativeLabType Type { get; }
        public MeasurementSystem MeasurementSystem { get; }

        internal static QuantitativeLab Create(double result, QuantitativeLabType type) => new QuantitativeLab(result, type);
    }
}
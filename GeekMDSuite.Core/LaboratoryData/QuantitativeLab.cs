namespace GeekMDSuite.Core.LaboratoryData
{
    public class QuantitativeLab : IQuantitativeLab
    {
        public QuantitativeLab() {}

        private QuantitativeLab(
            double result,
            QuantitativeLabType type,
            MeasurementSystem measurementSystem = MeasurementSystem.TraditionalUs) : this()
        {
            Result = result;
            Type = type;
            MeasurementSystem = measurementSystem;
        }
        public double Result { get; set; }
        
        public QuantitativeLabType Type { get; set; }
        
        public MeasurementSystem MeasurementSystem { get; set; }
        
        public override string ToString() => $"Quantitative Lab: {Type}, Result: {Result}";

        internal static QuantitativeLab Create(double result, QuantitativeLabType type) => new QuantitativeLab(result, type);
    }
}
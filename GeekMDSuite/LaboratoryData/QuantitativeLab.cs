namespace GeekMDSuite.LaboratoryData
{
    public class QuantitativeLab : IQuantitativeLab
    {
        private QuantitativeLab(double result, QuantitativeLabType type, MeasurementSystem measurementSystem = MeasurementSystem.TraditionalUs)
        {
            Result = result;
            Type = type;
            MeasurementSystem = measurementSystem;
        }
        public double Result { get; }
        public QuantitativeLabType Type { get; }
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public MeasurementSystem MeasurementSystem { get; }
        
        public override string ToString() => $"Quantitative Lab: {Type}, Result: {Result}";

        internal static QuantitativeLab Create(double result, QuantitativeLabType type) => new QuantitativeLab(result, type);
    }
}
namespace GeekMDSuite.Core.LaboratoryData.Panels
{
    public class BasicMetabolicPanel
    {
        public QuantitativeLab Sodium { get; set; }
        public QuantitativeLab Potassium { get; set; }
        public QuantitativeLab Chloride { get; set; }
        public QuantitativeLab Bicarbonate { get; set; }
        public QuantitativeLab BloodUreaNitrogen { get; set; }
        public QuantitativeLab Creatinine { get; set; }
        public QuantitativeLab Glucose { get; set; }

        public BasicMetabolicPanel()
        {
            Sodium = new QuantitativeLab();
            Potassium = new QuantitativeLab();
            Chloride = new QuantitativeLab();
            Bicarbonate = new QuantitativeLab();
            BloodUreaNitrogen = new QuantitativeLab();
            Creatinine = new QuantitativeLab();
            Glucose = new QuantitativeLab();
        }
    }
}
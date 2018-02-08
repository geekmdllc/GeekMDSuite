namespace GeekMDSuite.Core.LaboratoryData.Panels
{
    public class ComprehensiveMetabolicPanel
    {
        public QuantitativeLab Sodium { get; set; }
        public QuantitativeLab Potassium { get; set; }
        public QuantitativeLab Chloride { get; set; }
        public QuantitativeLab Bicarbonate { get; set; }
        public QuantitativeLab BloodUreaNitrogen { get; set; }
        public QuantitativeLab Creatinine { get; set; }
        public QuantitativeLab Glucose { get; set; }
        public QuantitativeLab TotalProtein { get; set; }
        public QuantitativeLab Albumin { get; set; }
        public QuantitativeLab AlkalinePhosphatase { get; set; }
        public QuantitativeLab TotalBilirubin { get; set; }
        public QuantitativeLab AlanineAminotransferase { get; set; }
        public QuantitativeLab AspartateAminotransferase { get; set; }

        public ComprehensiveMetabolicPanel()
        {
            Sodium = new QuantitativeLab();
            Potassium = new QuantitativeLab();
            Chloride = new QuantitativeLab();
            Bicarbonate = new QuantitativeLab();
            BloodUreaNitrogen = new QuantitativeLab();
            Creatinine = new QuantitativeLab();
            Glucose = new QuantitativeLab();
            TotalProtein = new QuantitativeLab();
            Albumin = new QuantitativeLab();
            AlkalinePhosphatase = new QuantitativeLab();
            TotalBilirubin = new QuantitativeLab();
            AlanineAminotransferase = new QuantitativeLab();
            AspartateAminotransferase = new QuantitativeLab();
        }
    }
}
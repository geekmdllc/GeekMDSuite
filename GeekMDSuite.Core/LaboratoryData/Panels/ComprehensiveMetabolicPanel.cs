namespace GeekMDSuite.Core.LaboratoryData.Panels
{
    public class ComprehensiveMetabolicPanel : BasicMetabolicPanel
    {
        public ComprehensiveMetabolicPanel()
        {
            TotalProtein = new QuantitativeLab();
            Albumin = new QuantitativeLab();
            AlkalinePhosphatase = new QuantitativeLab();
            TotalBilirubin = new QuantitativeLab();
            AlanineAminotransferase = new QuantitativeLab();
            AspartateAminotransferase = new QuantitativeLab();
        }

        public QuantitativeLab TotalProtein { get; set; }
        public QuantitativeLab Albumin { get; set; }
        public QuantitativeLab AlkalinePhosphatase { get; set; }
        public QuantitativeLab TotalBilirubin { get; set; }
        public QuantitativeLab AlanineAminotransferase { get; set; }
        public QuantitativeLab AspartateAminotransferase { get; set; }
    }
}
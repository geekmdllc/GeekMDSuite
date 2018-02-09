namespace GeekMDSuite.Core.LaboratoryData.Panels
{
    public class CompleteBloodCount
    {
        public QuantitativeLab WhiteBloodCells { get; set; }
        public QuantitativeLab RedBloodCells { get; set; }
        public QuantitativeLab MeanCorpuscularVolume { get; set; }
        public QuantitativeLab MeanCorpuscularHemoglobin { get; set; }
        public QuantitativeLab MeanCorpuscularHemoglobinConcentration { get; set; }
        public QuantitativeLab RedCellDistributionWidth { get; set; }
        public QuantitativeLab Hemoglobin { get; set; }
        public QuantitativeLab Hematocrit { get; set; }
        public QuantitativeLab Platelets { get; set; }

        public CompleteBloodCount()
        {
            WhiteBloodCells = new QuantitativeLab();
            RedBloodCells = new QuantitativeLab();
            MeanCorpuscularVolume = new QuantitativeLab();
            MeanCorpuscularHemoglobin = new QuantitativeLab();
            MeanCorpuscularHemoglobinConcentration = new QuantitativeLab();
            RedCellDistributionWidth = new QuantitativeLab();
            Hemoglobin = new QuantitativeLab();
            Hematocrit = new QuantitativeLab();
            Platelets = new QuantitativeLab();
        }
    }
}
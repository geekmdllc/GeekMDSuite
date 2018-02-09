namespace GeekMDSuite.Core.LaboratoryData.Panels
{
    public class CompleteBloodCountWithDifferential : CompleteBloodCount
    {
        public QuantitativeLab Neutrophils { get; set; }
        public QuantitativeLab Lymphocytes { get; set; }
        public QuantitativeLab Basophils { get; set; }
        public QuantitativeLab Eosinophils { get; set; }
        public QuantitativeLab Monocytes { get; set; }

        public CompleteBloodCountWithDifferential()
        {
            Neutrophils = new QuantitativeLab();
            Lymphocytes = new QuantitativeLab();
            Basophils = new QuantitativeLab();
            Eosinophils = new QuantitativeLab();
            Monocytes = new QuantitativeLab();
        }
    }
}
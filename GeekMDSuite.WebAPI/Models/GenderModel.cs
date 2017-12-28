namespace GeekMDSuite.WebAPI.Models
{
    public class GenderModel : IGender
    {
        public GenderIdentity Category { get; set; }
        public Genotype Genotype { get; set; }

        public GenderModel()
        {
            
        }

        public GenderModel(IGender gender)
        {
            Category = gender.Category;
            Genotype = gender.Genotype;
        }
    }
}
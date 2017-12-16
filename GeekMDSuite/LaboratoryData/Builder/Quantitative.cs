namespace GeekMDSuite.LaboratoryData.Builder
{
    public static class Quantitative
    {
        public static class Serum
        {
            public static QuantitativeLab Sodium(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.SodiumSerum);
            public static QuantitativeLab Potassium(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.PotassiumSerum);
            public static QuantitativeLab Chloride(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ChlorideSerum);
            public static QuantitativeLab Bicarbonate(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.BicarbonateSerum);
            public static QuantitativeLab BloodUreaNitrogen(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.BloodUreaNitrogenSerum);
            public static QuantitativeLab Creatinine(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.CreatinineSerum);
            public static QuantitativeLab Glucose(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.GlucoseSerum);
            public static QuantitativeLab Calcium(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.CalciumSerum);
            public static QuantitativeLab Protein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ProteinSerum);
            public static QuantitativeLab Albumin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.AlbuminSerum);
            public static QuantitativeLab AlkalinePhosphatase(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.AlkalinePhosphataseSerum);
            public static QuantitativeLab AspartateTransaminase(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.AspartateTransaminaseSerum);
            public static QuantitativeLab AlanineTransaminase(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.AlanineTransaminaseSerum);
            public static QuantitativeLab BilirubinTotal(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.BilirubinTotalSerum);
            public static QuantitativeLab CReactiveProtein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.CReactiveProteinSerum);
            public static QuantitativeLab LdlParticleSizeMean(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LdlParticleSizeMeanSerum);
            public static QuantitativeLab CholesterolTotal(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.CholesterolTotalSerum);
            public static QuantitativeLab HighDensityLipoprotein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HighDensityLipoproteinSerum);
            public static QuantitativeLab LowDensityLipoprotein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LowDensityLipoproteinSerum);
            public static QuantitativeLab LipoproteinA(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LipoproteinASerum);
            public static QuantitativeLab NonHdlLipoprotein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.NonHighDensityLipoproteinSerum);
            public static QuantitativeLab ThyroidStimulatingHormone(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ThyroidStimulatingHormoneSerum);
            public static QuantitativeLab VitaminD25Hydroxy(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.VitaminD25HydroxySerum);
            public static QuantitativeLab VitaminB12(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.VitaminB12Serum);
            public static QuantitativeLab Folate(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.FolateSerum);
            public static QuantitativeLab WhiteBloodCells(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.WhiteBloodCellsSerum);
            public static QuantitativeLab RedBloodCells(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.RedBloodCellsSerum);
            public static QuantitativeLab Hemoglobin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HemoglobinSerum);
            public static QuantitativeLab Insulin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.InsulinSerum);
            public static QuantitativeLab Hematocrit(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HematocritSerum);
            public static QuantitativeLab MeanCorpuscularVolume(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.MeanCorpuscularVolumeSerum);
            public static QuantitativeLab MeanCorpuscularHemoglobin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.MeanCorpuscularHemoglobinSerum);
            public static QuantitativeLab MeanCorpuscularHemoglobinConcentration(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.MeanCorpuscularHemoglobinConcentrationSerum);
            public static QuantitativeLab RedBloodCellDistributionWidth(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.RedBloodCellDistributionWidthCvSerum);
            public static QuantitativeLab Platelets(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.PlateletCountSerum);
            public static QuantitativeLab Neutrophils(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.NeutrophilsSerum);
            public static QuantitativeLab Lymphocytes(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LymphocytesSerum);
            public static QuantitativeLab Monocytes(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.MonocytesSerum);
            public static QuantitativeLab Eosinophils(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.EosinophilsSerum);
            public static QuantitativeLab Basophils(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.BasophilsSerum);
            public static QuantitativeLab HemoglobinA1CPercentage(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HemoglobinA1CSerum);
            public static QuantitativeLab ApolipoproteinB(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ApolipoproteinBSerum);
            public static QuantitativeLab SexHormoneBindingGlobulin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.SexHormoneBindingGlobulinSerum);
            public static QuantitativeLab TestosteroneFree(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.TestosteroneFreeSerum);
            public static QuantitativeLab TestosteroneTotal(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.TestosteroneTotalSerum);
            public static QuantitativeLab Estradiol(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.EstradiolSerum);
            public static QuantitativeLab BilirubinDirect(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.BilirubinDirectSerum);
            public static QuantitativeLab FollicularStimulatingHormone(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.FollicularStimulatingHormone);
            public static QuantitativeLab LeutenizingHormone(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LeutenizingHormone);
            public static QuantitativeLab Homocysteine(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HomocysteineSerum);
            public static QuantitativeLab Lipase(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.LipaseSerum);
            public static QuantitativeLab Magnesium(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.MagnesiumSerum);
            public static QuantitativeLab ProstateSpecificAntigen(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ProstateSpecificAntigenSerum);
            public static QuantitativeLab ProstateSpecificAntigenFree(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ProstateSpecificAntigenFreeSerum);
            public static QuantitativeLab ThyroxineFree(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ThyroxineFreeSerum);
            public static QuantitativeLab ThyroxineTotal(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ThyroxineTotalSerum);
            public static QuantitativeLab Triglycerides(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.TriglyceridesSerum);
            public static QuantitativeLab TriiodithyronineFree(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.TriiodothyronineFreeSerum);
            public static QuantitativeLab TriiodothyronineTotal(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.TriiodothyronineTotalSerum);
            public static QuantitativeLab ReverseTriiodothyronine(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ReverseTriiodothyronineSerum);
            public static QuantitativeLab UricAcid(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.UricAcidSerum); 
            public static QuantitativeLab VeryLowDensityLipoprotein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.VeryLowDensityLipoproteinSerum);
            
            // Commonly used aliases for otherwise confusing names.
            public static QuantitativeLab Bun(double result) => BloodUreaNitrogen(result);
            public static QuantitativeLab Crp(double result) => CReactiveProtein(result);
            public static QuantitativeLab T4Free(double result) => ThyroxineFree(result);
            public static QuantitativeLab T4Total(double result) => ThyroxineTotal(result);
            public static QuantitativeLab T3Free(double result) => TriiodithyronineFree(result);
            public static QuantitativeLab T3Total(double result) => TriiodothyronineTotal(result);
            public static QuantitativeLab ReverseT3(double result) => ReverseTriiodothyronine(result); 
        }

        public static class Urine
        {
            public static QuantitativeLab Protein(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.ProteinUrine);
            public static QuantitativeLab Glucose(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.GlucoseUrine);
            public static QuantitativeLab RedBloodCells(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.RedBloodCellsUrine);
            public static QuantitativeLab WhiteBloodCells(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.WhiteBloodCellsUrine);
            public static QuantitativeLab Hemoglobin(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.HemoglobinUrine);
            public static QuantitativeLab Ketones(double result) => 
                QuantitativeLab.Create(result, QuantitativeLabType.KetonesUrine);
        }
    }
}
namespace GeekMDSuite.Core.LaboratoryData.Builder
{
    public static class Qualitative
    {
        public static QualitativeLab HumanImmunodeficiencyVirusAntigen(QualitativeLabResult result) =>
            QualitativeLab.Create(QualitativeLabType.Hiv, result);
        
        public static QualitativeLab HepatitisCAntibody(QualitativeLabResult result) =>
            QualitativeLab.Create(QualitativeLabType.HepatitisC, result);
        
        public static QualitativeLab LdlSublcassPhenotype(QualitativeLabResult result) =>
            QualitativeLab.Create(QualitativeLabType.LdlSubclassPhenotype, result);
    }
}
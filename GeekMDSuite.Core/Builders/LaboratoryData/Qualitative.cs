using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.Core.Builders.LaboratoryData
{
    public static class Qualitative
    {
        public static QualitativeLab HumanImmunodeficiencyVirusAntigen(QualitativeLabResult result)
        {
            return QualitativeLab.Create(QualitativeLabType.Hiv, result);
        }

        public static QualitativeLab HepatitisCAntibody(QualitativeLabResult result)
        {
            return QualitativeLab.Create(QualitativeLabType.HepatitisC, result);
        }

        public static QualitativeLab LdlSublcassPhenotype(QualitativeLabResult result)
        {
            return QualitativeLab.Create(QualitativeLabType.LdlSubclassPhenotype, result);
        }
    }
}
namespace GeekMDSuite.Core.LaboratoryData
{
    public interface IQualitativeLab
    {
        QualitativeLabType Type { get; }
        QualitativeLabResult Result { get; }
    }
}
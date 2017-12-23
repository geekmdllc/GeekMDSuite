namespace GeekMDSuite.LaboratoryData
{
    public interface IQualitativeLab
    {
        QualitativeLabType Type { get; }
        QualitativeLabResult Result { get; }
    }
}
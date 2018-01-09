namespace GeekMDSuite.Core.LaboratoryData
{
    public class QualitativeLab
    {
        private QualitativeLab(QualitativeLabType type, QualitativeLabResult result)
        {
            Type = type;
            Result = result;
        }

        public QualitativeLabType Type { get; }
        public QualitativeLabResult Result { get; }

        public static QualitativeLab Create(QualitativeLabType type, QualitativeLabResult result)
        {
            return new QualitativeLab(type, result);
        }

        public override string ToString()
        {
            return Result.ToString();
        }
    }
}
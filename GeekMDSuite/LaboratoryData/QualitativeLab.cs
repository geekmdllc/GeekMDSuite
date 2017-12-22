namespace GeekMDSuite.LaboratoryData
{
    public class QualitativeLab
    {
        internal QualitativeLab(QualitativeLabType type, QualitativeLabResult result)
        {
            Type = type;
            Result = result;
        }

        public QualitativeLabType Type { get; }
        public QualitativeLabResult Result { get; }

        public static QualitativeLab Create(QualitativeLabType type, QualitativeLabResult result) 
            => new QualitativeLab(type, result);

        public override string ToString() => Result.ToString();
    }
}
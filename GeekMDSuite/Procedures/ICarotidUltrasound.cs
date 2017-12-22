namespace GeekMDSuite.Procedures
{
    public interface ICarotidUltrasound
    {
        CarotidUltrasoundResult Left { get; }
        CarotidUltrasoundResult Right { get; }
    }
}
namespace GeekMDSuite.Core.Procedures
{
    public interface ICarotidUltrasound
    {
        CarotidUltrasoundResult Left { get; set; }
        CarotidUltrasoundResult Right { get; set; }
    }
}
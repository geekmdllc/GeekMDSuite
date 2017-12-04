namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasound
    {
        public CarotidUltrasound(CarotidUltrasoundResult left, CarotidUltrasoundResult right)
        {
            Left = left;
            Right = right;
        }

        public CarotidUltrasoundResult Left { get;}
        public CarotidUltrasoundResult Right { get; }
    }
}
namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasound : ICarotidUltrasound
    {
        private CarotidUltrasound(CarotidUltrasoundResult left, CarotidUltrasoundResult right)
        {
            Left = left;
            Right = right;
        }

        public CarotidUltrasoundResult Left { get;}
        public CarotidUltrasoundResult Right { get; }

        public static CarotidUltrasound Build(CarotidUltrasoundResult left, CarotidUltrasoundResult right) => 
            new CarotidUltrasound(left, right);

        public override string ToString()
        {
            return $"Left: {Left}\nRight: {Right}";
        }
    }
}
namespace GeekMDSuite.Core.Models.Procedures
{
    public class CarotidUltrasound
    {
        private CarotidUltrasound(CarotidUltrasoundResult left, CarotidUltrasoundResult right)
        {
            Left = left;
            Right = right;
        }

        protected CarotidUltrasound()
        {
        }

        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }

        public static CarotidUltrasound Build(CarotidUltrasoundResult left, CarotidUltrasoundResult right)
        {
            return new CarotidUltrasound(left, right);
        }

        public override string ToString()
        {
            return $"Left: {Left}\nRight: {Right}";
        }
    }
}
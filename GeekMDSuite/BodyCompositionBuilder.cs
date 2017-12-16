namespace GeekMDSuite
{
    public class BodyCompositionBuilder
    {
        private double _heightInches;
        private double _waistInches;
        private double _hipsInches;
        private double _weightPounds;

        public BodyCompositionBuilder SetHeight(double inches)
        {
            _heightInches = inches;
            return this;
        }

        public BodyCompositionBuilder SetWaist(double inches)
        {
            _waistInches = inches;
            return this;
        }
        
        public BodyCompositionBuilder SetHips(double inches)
        {
            _hipsInches = inches;
            return this;
        }
        
        public BodyCompositionBuilder SetWeight(double pounds)
        {
            _weightPounds = pounds;
            return this;
        }

        public BodyComposition Build() => BodyComposition.Build(_heightInches, _waistInches, _hipsInches, _weightPounds);
    }
}
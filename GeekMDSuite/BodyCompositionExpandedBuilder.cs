namespace GeekMDSuite
{
    public class BodyCompositionExpandedBuilder
    {
        private double _heightInches;
        private double _waistInches;
        private double _hipsInches;
        private double _weightPounds;
        private double _visceralFatCm2;
        private double _percentBodyFat;

        public BodyCompositionExpandedBuilder SetHeight(double inches)
        {
            _heightInches = inches;
            return this;
        }

        public BodyCompositionExpandedBuilder SetWaist(double inches)
        {
            _waistInches = inches;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetHips(double inches)
        {
            _hipsInches = inches;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetWeight(double pounds)
        {
            _weightPounds = pounds;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetVisceralFat(double centimetersSquared)
        {
            _visceralFatCm2 = centimetersSquared;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetBodyFatPercentage(double percentage)
        {
            _percentBodyFat = percentage;
            return this;
        }

        public BodyCompositionExpanded Build() => 
            BodyCompositionExpanded.Build(
                BodyComposition.Build(_heightInches, _waistInches, _hipsInches, _weightPounds), 
                _visceralFatCm2, _percentBodyFat);
    }
}
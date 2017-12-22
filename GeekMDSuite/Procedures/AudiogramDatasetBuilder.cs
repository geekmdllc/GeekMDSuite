namespace GeekMDSuite.Procedures
{
    public class AudiogramDatasetBuilder : Builder<AudiogramDatasetBuilder, AudiogramDataset>
    {
        public override AudiogramDataset Build()
        {
            return AudiogramDataset.Build(_f125, _f250, _f500, _f1000, _f2000, _f3000, _f4000, _f6000, _f8000);
        }

        public AudiogramDatasetBuilder Set125HertzDataPoint(int value)
        {
            _f125 = new AudiogramDatapoint(value);
            return this;
        }
            
        public AudiogramDatasetBuilder Set250HertzDataPoint(int value)
        {
            _f250 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set500HertzDataPoint(int value)
        {
            _f500 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set1000HertzDataPoint(int value)
        {
            _f1000 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set2000HertzDataPoint(int value)
        {
            _f2000 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set3000HertzDataPoint(int value)
        {
            _f3000 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set4000HertzDataPoint(int value)
        {
            _f4000 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set6000HertzDataPoint(int value)
        {
            _f6000 = new AudiogramDatapoint(value);
            return this;
        }
        public AudiogramDatasetBuilder Set8000HertzDataPoint(int value)
        {
            _f8000 = new AudiogramDatapoint(value);
            return this;
        }
        
        private AudiogramDatapoint _f125;
        private AudiogramDatapoint _f250;
        private AudiogramDatapoint _f500;
        private AudiogramDatapoint _f1000;
        private AudiogramDatapoint _f2000;
        private AudiogramDatapoint _f3000;
        private AudiogramDatapoint _f4000;
        private AudiogramDatapoint _f6000;
        private AudiogramDatapoint _f8000;
    }
}

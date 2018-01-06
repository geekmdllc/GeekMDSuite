using System;
using System.Collections.Generic;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class IshiharaSixPlate
    {
        private readonly List<IshiharaPlateAnswer> _answers;

        protected internal IshiharaSixPlate()
        {
            Plate1 = new IshiharaPlateAnswer();
            Plate2 = new IshiharaPlateAnswer();
            Plate3 = new IshiharaPlateAnswer();
            Plate4 = new IshiharaPlateAnswer();
            Plate5 = new IshiharaPlateAnswer();
            Plate6 = new IshiharaPlateAnswer();
        }

        private IshiharaSixPlate(List<IshiharaPlateAnswer> plates)
        {
            _answers = plates ?? throw new ArgumentNullException(nameof(plates));

            Plate1 = GetAnswers()[0];
            Plate2 = GetAnswers()[1];
            Plate3 = GetAnswers()[2];
            Plate4 = GetAnswers()[3];
            Plate5 = GetAnswers()[4];
            Plate6 = GetAnswers()[5];
        }

        public IshiharaPlateAnswer Plate1 { get; set; }
        public IshiharaPlateAnswer Plate2 { get; set; }
        public IshiharaPlateAnswer Plate3 { get; set; }
        public IshiharaPlateAnswer Plate4 { get; set; }
        public IshiharaPlateAnswer Plate5 { get; set; }
        public IshiharaPlateAnswer Plate6 { get; set; }

        internal static IshiharaSixPlate Build(List<IshiharaPlateAnswer> plates)
        {
            return new IshiharaSixPlate(plates);
        }

        public List<IshiharaPlateAnswer> GetAnswers()
        {
            return _answers;
        }

        public override string ToString()
        {
            return string.Join("\n", GetAnswers());
        }
    }
}
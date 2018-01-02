using System;
using System.Collections.Generic;

namespace GeekMDSuite.Core.Procedures
{
    public class IshiharaSixPlate
    {
        public List<IshiharaPlateAnswer> Answers { get; }

        public IshiharaPlateAnswer Plate1 { get; set; }
        public IshiharaPlateAnswer Plate2 { get; set; }
        public IshiharaPlateAnswer Plate3 { get; set; }
        public IshiharaPlateAnswer Plate4 { get; set; }
        public IshiharaPlateAnswer Plate5 { get; set; }
        public IshiharaPlateAnswer Plate6 { get; set; }

        public IshiharaSixPlate() { }

        internal IshiharaSixPlate(List<IshiharaPlateAnswer> plates)
        {
            Answers = plates ?? throw new ArgumentNullException(nameof(plates));
            
            Plate1 = Answers[0];
            Plate1 = Answers[1];
            Plate1 = Answers[2];
            Plate1 = Answers[3];
            Plate1 = Answers[4];
            Plate1 = Answers[5];
        }

        public override string ToString()
        {
            return string.Join("\n", Answers);
        }
    }
}
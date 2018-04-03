using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class IshiharaSixPlate
    {
        private readonly IshiharaPlateAnswer[] _answers;

        protected internal IshiharaSixPlate()
        {
            _answers = new IshiharaPlateAnswer[6];
            Plate1 = new IshiharaPlateAnswer();
            Plate2 = new IshiharaPlateAnswer();
            Plate3 = new IshiharaPlateAnswer();
            Plate4 = new IshiharaPlateAnswer();
            Plate5 = new IshiharaPlateAnswer();
            Plate6 = new IshiharaPlateAnswer();
        }

        private IshiharaSixPlate(List<IshiharaPlateAnswer> plates) : this()
        {
            if (plates == null) throw new ArgumentNullException(nameof(plates));
            Plate1 = plates[0];
            Plate2 = plates[1];
            Plate3 = plates[2];
            Plate4 = plates[3];
            Plate5 = plates[4];
            Plate6 = plates[5];
        }

        private IshiharaPlateAnswer _plate1;
        public IshiharaPlateAnswer Plate1
        {
            get => _plate1;
            set => _plate1 = _answers[0] = value;
        }

        private IshiharaPlateAnswer _plate2;
        public IshiharaPlateAnswer Plate2
        {
            get => _plate2;
            set => _plate2 = _answers[1] = value;
        }

        private IshiharaPlateAnswer _plate3;
        public IshiharaPlateAnswer Plate3
        {
            get => _plate3;
            set => _plate3 = _answers[2] = value;
        }

        private IshiharaPlateAnswer _plate4;
        public IshiharaPlateAnswer Plate4
        {
            get => _plate4;
            set => _plate4 = _answers[3] = value;
        }

        private IshiharaPlateAnswer _plate5;
        public IshiharaPlateAnswer Plate5
        {
            get => _plate5;
            set => _plate5 = _answers[4] = value;
        }

        private IshiharaPlateAnswer _plate6;
        public IshiharaPlateAnswer Plate6
        {
            get => _plate6;
            set => _plate6 = _answers[5] = value;
        }

        internal static IshiharaSixPlate Build(List<IshiharaPlateAnswer> plates)
        {
            return new IshiharaSixPlate(plates);
        }

        public List<IshiharaPlateAnswer> GetAnswers() => _answers.ToList();

        public override string ToString() => string.Join("\n", GetAnswers());
    }
}
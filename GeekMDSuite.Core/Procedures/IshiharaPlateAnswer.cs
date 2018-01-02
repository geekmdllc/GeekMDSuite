﻿using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.Core.Procedures
{
    public class IshiharaPlateAnswer : IIshiharaPlateAnswer
    {

        internal static IshiharaPlateAnswer Build(int plateNumber, IshiharaAnswerResult plateRead) => 
            new IshiharaPlateAnswer(plateNumber, plateRead);

        private IshiharaPlateAnswer(int plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }

        protected internal IshiharaPlateAnswer()
        {
            
        }
        public int PlateNumber { get; set; }
        public IshiharaAnswerResult PlateRead { get; set; }

        public override string ToString() => $"#{PlateNumber} - {PlateRead}";
    }
}
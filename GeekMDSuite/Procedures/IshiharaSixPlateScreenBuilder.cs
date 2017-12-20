using System;
using System.Collections.Generic;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public class IshiharaSixPlateScreenBuilder : Builder<IshiharaSixPlateScreenBuilder, List<IshiharaPlateAnswer>>
    {
        public override List<IshiharaPlateAnswer> Build()
        {
            ValidatePreBuildState();
            return _list;
        }

        public IshiharaSixPlateScreenBuilder SetPlate1(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(1, plateRead);
            return this;
        }

        public IshiharaSixPlateScreenBuilder SetPlate2(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(2, plateRead);
            return this;
        }
        public IshiharaSixPlateScreenBuilder SetPlate3(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(3, plateRead);
            return this;
        }
        public IshiharaSixPlateScreenBuilder SetPlate4(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(4, plateRead);
            return this;
        }
        public IshiharaSixPlateScreenBuilder SetPlate5(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(5, plateRead);
            return this;
        }
        public IshiharaSixPlateScreenBuilder SetPlate6(IshiharaAnswerResult plateRead)
        {
            SetPlateValueByPosition(6, plateRead);
            return this;
        }
                
        private readonly List<IshiharaPlateAnswer> _list = new List<IshiharaPlateAnswer>();
        
        private void SetPlateValueByPosition(int plateNumber, IshiharaAnswerResult plateRead)
        {
            var index = plateNumber - 1;
            if (_list.Count >= 6)
            {
                _list.RemoveAt(index);
                _list.Insert(index, IshiharaPlateAnswer.Build(plateNumber, plateRead));
                return;
            }
            _list.Add(IshiharaPlateAnswer.Build(plateNumber, plateRead));
        }
        
        private void ValidatePreBuildState()
        {
            if (_list.Count != 6)
                throw new IndexOutOfRangeException(
                    $"{nameof(IshiharaSixPlateScreenBuilder)} has {_list.Count} of 6 plates set.");
            foreach (var plate in _list)
            {
                if (plate.PlateNumber != _list.IndexOf(plate) + 1)
                    throw new IndexOutOfRangeException(
                        $"{nameof(IshiharaSixPlateScreenBuilder)} has plate number {plate.PlateNumber} in index position {_list.IndexOf(plate)}.");
            }
        }
    }
}
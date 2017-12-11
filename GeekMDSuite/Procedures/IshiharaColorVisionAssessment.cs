using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Procedures
{
    public class IshiharaColorVisionAssessment
    {
        public IshiharaColorVisionAssessment(IshiharaTestType testType, List<IshiharaPlateAnswer> answerList)
        {
            TestType = testType;
            AnswerList = answerList;
            
            // Get the plate set for the selected test type to serve as a reference

            _selectedPlateSet = IshiharaPlateSetRepository.SixPlateScreen();

            // Do not accept more than the correct number of plates for the identified set.
            var tmp = from answer in answerList
                where answer.PlateNumber <= _selectedPlateSet.Count()
                select answer;

            AnswerList = tmp.ToList();
        }
        
        public IshiharaTestType TestType { get; }
        public List<IshiharaPlateAnswer> AnswerList { get; }

        //TODO Move to interpretation section
        public IshiharaResultFlag ResultFlag { get { return this.AssessIshiharaVisionAssessment(); }}
        
        private readonly List<IshiharaPlate> _selectedPlateSet;
        
        private IshiharaResultFlag AssessIshiharaVisionAssessment() {
            // 6 Plate interpretation: counts all 6 plates, details in verious other handbooks. | 6 to pass
            // 10 plate interpetation: looking for details??? 
            // 14 Plate interpretation: Only counts plates 1 to 11 | 
            // https://web.stanford.edu/group/vista/wikiupload/0/0a/Ishihara.14.Plate.Instructions.pdf
            // 24 Plate interpretation: Only counts plates 1 to 15 | 13 to pass
            // http://www.dfis.ubi.pt/~hgil/P.V.2/Ishihara/Ishihara.24.Plate.TEST.Book.pdf
            // 38 Plate interpretation: only counts plates 1 to 21 | 17 to pass
            // http://zonemedical.com.au/c.728341/site/PDF/PAL/Ishihara-Test-User-Manual.pdf

            switch (this.TestType) {
                case IshiharaTestType.Ishihara6:
                    return EvaluatePassFailAlgorith(5,6,6);
                case IshiharaTestType.Ishihara10:
                    throw new NotImplementedException();
                case IshiharaTestType.Ishihara14:
                    return EvaluatePassFailAlgorith(7,10,11);
                case IshiharaTestType.Ishihara24:
                    return EvaluatePassFailAlgorith(9,13,15);
                case IshiharaTestType.Ishihara38:
                    return EvaluatePassFailAlgorith(13,17,21);
            }

            throw new NotImplementedException();
        }

        private IshiharaResultFlag EvaluatePassFailAlgorith(ushort upperLimitOfFail, ushort lowerLimitOfPass, ushort slidesToEvaluate)
        {
            int count = 0;
            foreach(var answer in this.AnswerList) {
                        if (answer.PlateRead == IshiharaAnswerResult.NormalVision &&
                            answer.PlateNumber <= slidesToEvaluate) {
                            count++;
                        }
                    }
                    
            if (count >= lowerLimitOfPass) return IshiharaResultFlag.NormalVision;
            else if (count <= upperLimitOfFail) return IshiharaResultFlag.ColorVisionDeficit;
            else return IshiharaResultFlag.IndeterminantResult;
        }
    }

    public class IshiharaPlateAnswer {

        public IshiharaPlateAnswer(ushort plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }
        public ushort PlateNumber { get; }
        public IshiharaAnswerResult PlateRead { get;  }

    }
    
    public class IshiharaPlate 
    {
        public ushort PlateNumber { get; }
        public IshiharaPlateType PlateType  { get; }
        public string NormalVisionRead { get; }
        public string RedGreenDeficientRead { get; }
        public string TotalColorBlindnessRead { get; }

        public IshiharaPlate(ushort plateNumber, IshiharaPlateType plateType, 
            string normalVisionRead, string redGreenDeficientRead, string totalColorBindnessRead) 
        {
            PlateNumber = plateNumber;
            PlateType = plateType;
            NormalVisionRead = normalVisionRead;
            RedGreenDeficientRead = redGreenDeficientRead;
            TotalColorBlindnessRead = totalColorBindnessRead;
        }
    }
    
    public static class IshiharaPlateSetRepository
    {
        public static List<IshiharaPlate> SixPlateScreen() => GetSet(IshiharaTestType.Ishihara6);
        public static List<IshiharaPlate> FourteenPlateScreen() => GetSet(IshiharaTestType.Ishihara14);
        public static List<IshiharaPlate> TwentyFourPlateScreen() => GetSet(IshiharaTestType.Ishihara24);
        public static List<IshiharaPlate> ThirtyEightPlateScreen() => GetSet(IshiharaTestType.Ishihara38);
        
        private static List<IshiharaPlate> GetSet(IshiharaTestType testType) {
            
            List<IshiharaPlate> plates = new List<IshiharaPlate>();
            string _unableToRead = "Blank";
            string _traceable = "Traceable";
            string _protanomaliaTracable = "Purple";
            string _deauteranomaliaTraceable = "Red";
            string _traceableBGYG = "Blue-green and yellow-green line.";
            string _traceableVO = "Violet and orange line.";
            string _traceableBGV = "Blue-green and violet line.";
            string _traceableRGV = "Red-green and violet line";

            switch (testType) {
                case IshiharaTestType.Ishihara6:
                    plates.Add(new IshiharaPlate(1, IshiharaPlateType.Numeral, "12", "12", "12"));
                    plates.Add(new IshiharaPlate(2, IshiharaPlateType.Numeral, "5", "70", _unableToRead));
                    plates.Add(new IshiharaPlate(3, IshiharaPlateType.Numeral, "26", ProtanDeutanDiff("6","2"), _unableToRead));
                    plates.Add(new IshiharaPlate(4, IshiharaPlateType.Numeral, "6", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(5, IshiharaPlateType.Numeral, "16", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(6, IshiharaPlateType.Numeral, _unableToRead, "5", _unableToRead));
                    break;

                case IshiharaTestType.Ishihara10:
                    throw new NotImplementedException();

                case IshiharaTestType.Ishihara14:
                    plates.Add(new IshiharaPlate(1, IshiharaPlateType.Numeral, "12", "12", "12"));
                    plates.Add(new IshiharaPlate(2, IshiharaPlateType.Numeral, "8", "3", _unableToRead));
                    plates.Add(new IshiharaPlate(3, IshiharaPlateType.Numeral, "5", "2", _unableToRead));
                    plates.Add(new IshiharaPlate(4, IshiharaPlateType.Numeral, "29", "70", _unableToRead));
                    plates.Add(new IshiharaPlate(5, IshiharaPlateType.Numeral, "74", "21", _unableToRead));
                    plates.Add(new IshiharaPlate(6, IshiharaPlateType.Numeral, "7", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(7, IshiharaPlateType.Numeral, "45", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(8, IshiharaPlateType.Numeral, "2", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(9, IshiharaPlateType.Numeral, _unableToRead, "2", _unableToRead));
                    plates.Add(new IshiharaPlate(10, IshiharaPlateType.Numeral, "16", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(11, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(12, IshiharaPlateType.NumeralProtanDuetan, "35", ProtanDeutanDiff("5","3"), _unableToRead));
                    plates.Add(new IshiharaPlate(13, IshiharaPlateType.NumeralProtanDuetan, "96", ProtanDeutanDiff("6","9"), _unableToRead));
                    plates.Add(new IshiharaPlate(14, IshiharaPlateType.Traceable, _traceable, ProtanDeutanDiff( _protanomaliaTracable, _deauteranomaliaTraceable), _unableToRead));
                    break;
                    
                case IshiharaTestType.Ishihara24:
                    plates.Add(new IshiharaPlate(1, IshiharaPlateType.Numeral, "12", "12", "12"));
                    plates.Add(new IshiharaPlate(2, IshiharaPlateType.Numeral, "8", "3", _unableToRead));
                    plates.Add(new IshiharaPlate(3, IshiharaPlateType.Numeral, "29", "70", _unableToRead));
                    plates.Add(new IshiharaPlate(4, IshiharaPlateType.Numeral, "5", "2", _unableToRead));
                    plates.Add(new IshiharaPlate(5, IshiharaPlateType.Numeral, "3", "5", _unableToRead));
                    plates.Add(new IshiharaPlate(6, IshiharaPlateType.Numeral, "15", "17", _unableToRead));
                    plates.Add(new IshiharaPlate(7, IshiharaPlateType.Numeral, "74", "21", _unableToRead));
                    plates.Add(new IshiharaPlate(8, IshiharaPlateType.Numeral, "6", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(9, IshiharaPlateType.Numeral, "45", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(10, IshiharaPlateType.Numeral, "5", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(11, IshiharaPlateType.Numeral, "7", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(12, IshiharaPlateType.Numeral, "16", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(13, IshiharaPlateType.Numeral, "73", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(14, IshiharaPlateType.Numeral, _unableToRead, "5", _unableToRead));
                    plates.Add(new IshiharaPlate(15, IshiharaPlateType.Numeral, _unableToRead, "45", _unableToRead));
                    plates.Add(new IshiharaPlate(16, IshiharaPlateType.NumeralProtanDuetan, "26", ProtanDeutanDiff("6","2"), _unableToRead));
                    plates.Add(new IshiharaPlate(17, IshiharaPlateType.NumeralProtanDuetan, "42", ProtanDeutanDiff("2","4"), _unableToRead));
                    plates.Add(new IshiharaPlate(18, IshiharaPlateType.Traceable, _traceable, ProtanDeutanDiff( _protanomaliaTracable, _deauteranomaliaTraceable), _unableToRead));
                    plates.Add(new IshiharaPlate(19, IshiharaPlateType.Traceable, _unableToRead, _traceable, _unableToRead));
                    plates.Add(new IshiharaPlate(20, IshiharaPlateType.Traceable, _traceableBGYG, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(21, IshiharaPlateType.Traceable, _traceableVO, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(22, IshiharaPlateType.Traceable, _traceableBGYG, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(23, IshiharaPlateType.Traceable, _traceableVO, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(24, IshiharaPlateType.Traceable, _traceable, _traceable, _traceable));
                    break;
                    
                case IshiharaTestType.Ishihara38:
                    plates.Add(new IshiharaPlate(1, IshiharaPlateType.Numeral, "12", "12", "12"));
                    plates.Add(new IshiharaPlate(2, IshiharaPlateType.Numeral, "8", "3", _unableToRead));
                    plates.Add(new IshiharaPlate(3, IshiharaPlateType.Numeral, "6", "5", _unableToRead));
                    plates.Add(new IshiharaPlate(4, IshiharaPlateType.Numeral, "29", "70", _unableToRead));
                    plates.Add(new IshiharaPlate(5, IshiharaPlateType.Numeral, "57", "35", _unableToRead));
                    plates.Add(new IshiharaPlate(6, IshiharaPlateType.Numeral, "5", "2", _unableToRead));
                    plates.Add(new IshiharaPlate(7, IshiharaPlateType.Numeral, "3", "5", _unableToRead));
                    plates.Add(new IshiharaPlate(8, IshiharaPlateType.Numeral, "15", "17", _unableToRead));
                    plates.Add(new IshiharaPlate(9, IshiharaPlateType.Numeral, "74", "21", _unableToRead));
                    plates.Add(new IshiharaPlate(10, IshiharaPlateType.Numeral, "2", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(11, IshiharaPlateType.Numeral, "6", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(12, IshiharaPlateType.Numeral, "97", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(13, IshiharaPlateType.Numeral, "45", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(14, IshiharaPlateType.Numeral, "5", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(15, IshiharaPlateType.Numeral, "7", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(16, IshiharaPlateType.Numeral, "16", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(17, IshiharaPlateType.Numeral, "73", _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(18, IshiharaPlateType.Numeral, _unableToRead, "2", _unableToRead));
                    plates.Add(new IshiharaPlate(19, IshiharaPlateType.Numeral, _unableToRead, "2", _unableToRead));
                    plates.Add(new IshiharaPlate(20, IshiharaPlateType.Numeral, _unableToRead, "45", _unableToRead));
                    plates.Add(new IshiharaPlate(21, IshiharaPlateType.Numeral, _unableToRead, "73", _unableToRead));
                    plates.Add(new IshiharaPlate(22, IshiharaPlateType.NumeralProtanDuetan, "26", ProtanDeutanDiff("6","2"), _unableToRead));
                    plates.Add(new IshiharaPlate(23, IshiharaPlateType.NumeralProtanDuetan, "42", ProtanDeutanDiff("2","4"), _unableToRead));
                    plates.Add(new IshiharaPlate(24, IshiharaPlateType.NumeralProtanDuetan, "35", ProtanDeutanDiff("5","3"), _unableToRead));
                    plates.Add(new IshiharaPlate(25, IshiharaPlateType.NumeralProtanDuetan, "96", ProtanDeutanDiff("6","9"), _unableToRead));
                    plates.Add(new IshiharaPlate(26, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(27, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(28, IshiharaPlateType.Traceable, _unableToRead, _traceable, _unableToRead));
                    plates.Add(new IshiharaPlate(29, IshiharaPlateType.Traceable, _unableToRead, _traceable, _unableToRead));
                    plates.Add(new IshiharaPlate(30, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(31, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(32, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(33, IshiharaPlateType.Traceable, _traceable, _unableToRead, _unableToRead));
                    plates.Add(new IshiharaPlate(34, IshiharaPlateType.Traceable, _traceableBGYG, _traceableRGV, _unableToRead));
                    plates.Add(new IshiharaPlate(35, IshiharaPlateType.Traceable, _traceableBGYG, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(36, IshiharaPlateType.Traceable, _traceableVO, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(37, IshiharaPlateType.Traceable, _traceableVO, _traceableBGV, _unableToRead));
                    plates.Add(new IshiharaPlate(38, IshiharaPlateType.Traceable, _traceable, _traceable, _traceable));
                    break; 
                    
                default:
                    throw new NotImplementedException();
                    
            }

            return plates;
        }
        private static string ProtanDeutanDiff(string protanStrong, string deutanStrong) {

            return String.Format($"P: {protanStrong}/({deutanStrong}){protanStrong} D: {deutanStrong}/{deutanStrong}({protanStrong})");
        }
    }
}
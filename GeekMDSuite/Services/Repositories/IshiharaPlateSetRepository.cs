using System;
using System.Collections.Generic;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Services.Repositories
{
    internal static class IshiharaPlateSetRepository
    {
        public static List<IshiharaPlateModel> SixPlateScreen() => GetSet(IshiharaTestType.Ishihara6);
        public static List<IshiharaPlateModel> FourteenPlateScreen() => GetSet(IshiharaTestType.Ishihara14);
        public static List<IshiharaPlateModel> TenPlateScreen() => throw new NotImplementedException(nameof(IshiharaPlateSetRepository));
        public static List<IshiharaPlateModel> TwentyFourPlateScreen() => GetSet(IshiharaTestType.Ishihara24);
        public static List<IshiharaPlateModel> ThirtyEightPlateScreen() => GetSet(IshiharaTestType.Ishihara38);
        
        private static List<IshiharaPlateModel> GetSet(IshiharaTestType testType) {
            
            var plates = new List<IshiharaPlateModel>();
            
            if (testType == IshiharaTestType.Ishihara6) InitializeSixPlate(plates);
            if (testType == IshiharaTestType.Ishihara10) throw new NotImplementedException();
            if (testType == IshiharaTestType.Ishihara14) InitializeFourteenPlate(plates);
            if (testType == IshiharaTestType.Ishihara24) InitializeTwentyFourPlate(plates);
            if (testType == IshiharaTestType.Ishihara38) InitializeThirtyEightPlate(plates);
            
            return plates;
        }
        private const string UnableToRead = "Blank";
        private const string Traceable = "Traceable";
        private const string ProtanomaliaTracable = "Purple";
        private const string DeauteranomaliaTraceable = "Red";
        private const string TraceableBgyg = "Blue-green and yellow-green line.";
        private const string TraceableVo = "Violet and orange line.";
        private const string TraceableBgv = "Blue-green and violet line.";
        private const string TraceableRgv = "Red-green and violet line";
        private static string ProtanDeutanDiffentiation(string protanStronger, string deutanStronger) => 
            string.Format($"P: {protanStronger}/({deutanStronger}){protanStronger} D: {deutanStronger}/{deutanStronger}({protanStronger})");

        private static void InitializeThirtyEightPlate(ICollection<IshiharaPlateModel> plates)
        {
            plates.Add(new IshiharaPlateModel(1, IshiharaPlateType.Numeral, "12", "12", "12"));
            plates.Add(new IshiharaPlateModel(2, IshiharaPlateType.Numeral, "8", "3", UnableToRead));
            plates.Add(new IshiharaPlateModel(3, IshiharaPlateType.Numeral, "6", "5", UnableToRead));
            plates.Add(new IshiharaPlateModel(4, IshiharaPlateType.Numeral, "29", "70", UnableToRead));
            plates.Add(new IshiharaPlateModel(5, IshiharaPlateType.Numeral, "57", "35", UnableToRead));
            plates.Add(new IshiharaPlateModel(6, IshiharaPlateType.Numeral, "5", "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(7, IshiharaPlateType.Numeral, "3", "5", UnableToRead));
            plates.Add(new IshiharaPlateModel(8, IshiharaPlateType.Numeral, "15", "17", UnableToRead));
            plates.Add(new IshiharaPlateModel(9, IshiharaPlateType.Numeral, "74", "21", UnableToRead));
            plates.Add(new IshiharaPlateModel(10, IshiharaPlateType.Numeral, "2", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(11, IshiharaPlateType.Numeral, "6", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(12, IshiharaPlateType.Numeral, "97", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(13, IshiharaPlateType.Numeral, "45", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(14, IshiharaPlateType.Numeral, "5", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(15, IshiharaPlateType.Numeral, "7", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(16, IshiharaPlateType.Numeral, "16", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(17, IshiharaPlateType.Numeral, "73", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(18, IshiharaPlateType.Numeral, UnableToRead, "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(19, IshiharaPlateType.Numeral, UnableToRead, "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(20, IshiharaPlateType.Numeral, UnableToRead, "45", UnableToRead));
            plates.Add(new IshiharaPlateModel(21, IshiharaPlateType.Numeral, UnableToRead, "73", UnableToRead));
            plates.Add(new IshiharaPlateModel(22, IshiharaPlateType.NumeralProtanDuetan, "26", ProtanDeutanDiffentiation("6", "2"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(23, IshiharaPlateType.NumeralProtanDuetan, "42", ProtanDeutanDiffentiation("2", "4"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(24, IshiharaPlateType.NumeralProtanDuetan, "35", ProtanDeutanDiffentiation("5", "3"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(25, IshiharaPlateType.NumeralProtanDuetan, "96", ProtanDeutanDiffentiation("6", "9"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(26, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(27, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(28, IshiharaPlateType.Traceable, UnableToRead, Traceable, UnableToRead));
            plates.Add(new IshiharaPlateModel(29, IshiharaPlateType.Traceable, UnableToRead, Traceable, UnableToRead));
            plates.Add(new IshiharaPlateModel(30, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(31, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(32, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(33, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(34, IshiharaPlateType.Traceable, TraceableBgyg, TraceableRgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(35, IshiharaPlateType.Traceable, TraceableBgyg, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(36, IshiharaPlateType.Traceable, TraceableVo, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(37, IshiharaPlateType.Traceable, TraceableVo, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(38, IshiharaPlateType.Traceable, Traceable, Traceable, Traceable));
        }

        private static void InitializeTwentyFourPlate(ICollection<IshiharaPlateModel> plates)
        {
            plates.Add(new IshiharaPlateModel(1, IshiharaPlateType.Numeral, "12", "12", "12"));
            plates.Add(new IshiharaPlateModel(2, IshiharaPlateType.Numeral, "8", "3", UnableToRead));
            plates.Add(new IshiharaPlateModel(3, IshiharaPlateType.Numeral, "29", "70", UnableToRead));
            plates.Add(new IshiharaPlateModel(4, IshiharaPlateType.Numeral, "5", "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(5, IshiharaPlateType.Numeral, "3", "5", UnableToRead));
            plates.Add(new IshiharaPlateModel(6, IshiharaPlateType.Numeral, "15", "17", UnableToRead));
            plates.Add(new IshiharaPlateModel(7, IshiharaPlateType.Numeral, "74", "21", UnableToRead));
            plates.Add(new IshiharaPlateModel(8, IshiharaPlateType.Numeral, "6", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(9, IshiharaPlateType.Numeral, "45", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(10, IshiharaPlateType.Numeral, "5", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(11, IshiharaPlateType.Numeral, "7", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(12, IshiharaPlateType.Numeral, "16", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(13, IshiharaPlateType.Numeral, "73", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(14, IshiharaPlateType.Numeral, UnableToRead, "5", UnableToRead));
            plates.Add(new IshiharaPlateModel(15, IshiharaPlateType.Numeral, UnableToRead, "45", UnableToRead));
            plates.Add(new IshiharaPlateModel(16, IshiharaPlateType.NumeralProtanDuetan, "26", ProtanDeutanDiffentiation("6", "2"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(17, IshiharaPlateType.NumeralProtanDuetan, "42", ProtanDeutanDiffentiation("2", "4"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(18, IshiharaPlateType.Traceable, Traceable,
                ProtanDeutanDiffentiation(ProtanomaliaTracable, DeauteranomaliaTraceable), UnableToRead));
            plates.Add(new IshiharaPlateModel(19, IshiharaPlateType.Traceable, UnableToRead, Traceable, UnableToRead));
            plates.Add(new IshiharaPlateModel(20, IshiharaPlateType.Traceable, TraceableBgyg, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(21, IshiharaPlateType.Traceable, TraceableVo, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(22, IshiharaPlateType.Traceable, TraceableBgyg, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(23, IshiharaPlateType.Traceable, TraceableVo, TraceableBgv, UnableToRead));
            plates.Add(new IshiharaPlateModel(24, IshiharaPlateType.Traceable, Traceable, Traceable, Traceable));
        }

        private static void InitializeFourteenPlate(ICollection<IshiharaPlateModel> plates)
        {
            plates.Add(new IshiharaPlateModel(1, IshiharaPlateType.Numeral, "12", "12", "12"));
            plates.Add(new IshiharaPlateModel(2, IshiharaPlateType.Numeral, "8", "3", UnableToRead));
            plates.Add(new IshiharaPlateModel(3, IshiharaPlateType.Numeral, "5", "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(4, IshiharaPlateType.Numeral, "29", "70", UnableToRead));
            plates.Add(new IshiharaPlateModel(5, IshiharaPlateType.Numeral, "74", "21", UnableToRead));
            plates.Add(new IshiharaPlateModel(6, IshiharaPlateType.Numeral, "7", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(7, IshiharaPlateType.Numeral, "45", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(8, IshiharaPlateType.Numeral, "2", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(9, IshiharaPlateType.Numeral, UnableToRead, "2", UnableToRead));
            plates.Add(new IshiharaPlateModel(10, IshiharaPlateType.Numeral, "16", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(11, IshiharaPlateType.Traceable, Traceable, UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(12, IshiharaPlateType.NumeralProtanDuetan, "35", ProtanDeutanDiffentiation("5", "3"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(13, IshiharaPlateType.NumeralProtanDuetan, "96", ProtanDeutanDiffentiation("6", "9"),
                UnableToRead));
            plates.Add(new IshiharaPlateModel(14, IshiharaPlateType.Traceable, Traceable,
                ProtanDeutanDiffentiation(ProtanomaliaTracable, DeauteranomaliaTraceable), UnableToRead));
        }

        private static void InitializeSixPlate(ICollection<IshiharaPlateModel> plates)
        {
            plates.Add(new IshiharaPlateModel(1, IshiharaPlateType.Numeral, "12", "12", "12"));
            plates.Add(new IshiharaPlateModel(2, IshiharaPlateType.Numeral, "5", "70", UnableToRead));
            plates.Add(new IshiharaPlateModel(3, IshiharaPlateType.Numeral, "26", ProtanDeutanDiffentiation("6", "2"), UnableToRead));
            plates.Add(new IshiharaPlateModel(4, IshiharaPlateType.Numeral, "6", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(5, IshiharaPlateType.Numeral, "16", UnableToRead, UnableToRead));
            plates.Add(new IshiharaPlateModel(6, IshiharaPlateType.Numeral, UnableToRead, "5", UnableToRead));
        }
    }
}
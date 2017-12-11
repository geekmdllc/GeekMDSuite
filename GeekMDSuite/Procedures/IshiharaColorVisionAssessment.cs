using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Services.Respositories;

namespace GeekMDSuite.Procedures
{
    public class IshiharaSixPlateAssessment : IshiharaColorVisionAssessment
    {
        public IshiharaSixPlateAssessment(List<IshiharaPlateAnswer> answerList) : base(answerList, IshiharaTestType.Ishihara6)
        {
            PlateSet = IshiharaPlateSetRepository.SixPlateScreen();
        }
        protected sealed override List<IshiharaPlate> PlateSet { get; set; }
    }
    
    public abstract class IshiharaColorVisionAssessment
    {
        protected IshiharaColorVisionAssessment(List<IshiharaPlateAnswer> answerList, IshiharaTestType testType)
        {
            if (answerList == null) throw new ArgumentNullException(nameof(answerList));

            TestType = testType;
            
            // Do not accept more than the correct number of plates for the identified set.
            AnswerList = answerList.Where(a => a.PlateNumber <= PlateSet.Count()).ToList();
        }
        
        public IshiharaTestType TestType { get; }
        public List<IshiharaPlateAnswer> AnswerList { get; }
        protected abstract List<IshiharaPlate> PlateSet { get; set; }

        //TODO Move to interpretation section
        public IshiharaResultFlag ResultFlag => AssessIshiharaVisionAssessment();

        private IshiharaResultFlag AssessIshiharaVisionAssessment()
        {
            if (TestType == IshiharaTestType.Ishihara6)
                return EvaluatePlateAnswers(new IshiharaPlateReadLimitsByScreenType(5, 6, IshiharaTestType.Ishihara6));
            if (TestType == IshiharaTestType.Ishihara10)
                throw new NotImplementedException();
            if (TestType == IshiharaTestType.Ishihara14)
                return EvaluatePlateAnswers(new IshiharaPlateReadLimitsByScreenType(7, 10, IshiharaTestType.Ishihara14));
            return EvaluatePlateAnswers(TestType == IshiharaTestType.Ishihara24 
                ? new IshiharaPlateReadLimitsByScreenType(9, 13, IshiharaTestType.Ishihara24) 
                : new IshiharaPlateReadLimitsByScreenType(13, 17, IshiharaTestType.Ishihara38));
            
            // 6 Plate: All 6 required to pass
            // 10 plate interpetation: looking for details??? 
            // 14 Plate interpretation: Only counts plates 1 to 11 | 10 to pass
            // https://web.stanford.edu/group/vista/wikiupload/0/0a/Ishihara.14.Plate.Instructions.pdf
            // 24 Plate interpretation: Only counts plates 1 to 15 | 13 to pass
            // http://www.dfis.ubi.pt/~hgil/P.V.2/Ishihara/Ishihara.24.Plate.TEST.Book.pdf
            // 38 Plate interpretation: only counts plates 1 to 21 | 17 to pass
            // http://zonemedical.com.au/c.728341/site/PDF/PAL/Ishihara-Test-User-Manual.pdf
        }

        private IshiharaResultFlag EvaluatePlateAnswers(IshiharaPlateReadLimitsByScreenType limits)
        {
            var count = AnswerList.Count(CompareNormalPlateReadCountToLimits(limits));

            if (count >= limits.LowerLimitOfPass) return IshiharaResultFlag.NormalVision;
            
            return count <= limits.UpperLimitOfFail ? IshiharaResultFlag.ColorVisionDeficit : IshiharaResultFlag.IndeterminantResult;
        }

        private static Func<IshiharaPlateAnswer, bool> CompareNormalPlateReadCountToLimits(IshiharaPlateReadLimitsByScreenType ishiharaPlateReadLimitsByScreenType)
        {
            return ans => ans.PlateRead == IshiharaAnswerResult.NormalVision && ans.PlateNumber <= ishiharaPlateReadLimitsByScreenType.SlidesToEvaluate;
        }
    }

    
    public class IshiharaPlateAnswer {

        public IshiharaPlateAnswer(int plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }
        public int PlateNumber { get; }
        public IshiharaAnswerResult PlateRead { get;  }

    }
    
    public class IshiharaPlate 
    {
        public int PlateNumber { get; }
        public IshiharaPlateType PlateType  { get; }
        public string NormalVisionRead { get; }
        public string RedGreenDeficientRead { get; }
        public string TotalColorBlindnessRead { get; }

        public IshiharaPlate(int plateNumber, IshiharaPlateType plateType, 
            string normalVisionRead, string redGreenDeficientRead, string totalColorBindnessRead) 
        {
            PlateNumber = plateNumber;
            PlateType = plateType;
            NormalVisionRead = normalVisionRead;
            RedGreenDeficientRead = redGreenDeficientRead;
            TotalColorBlindnessRead = totalColorBindnessRead;
        }
    }
}
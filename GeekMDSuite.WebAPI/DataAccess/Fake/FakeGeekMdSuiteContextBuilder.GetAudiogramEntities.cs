using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<AudiogramEntity> GetAudiogramEntities()
        {
            var left = AudiogramDatasetBuilder.Initialize()
                .Set125HertzDataPoint(10)
                .Set250HertzDataPoint(10)
                .Set500HertzDataPoint(90)
                .Set1000HertzDataPoint(25)
                .Set2000HertzDataPoint(30)
                .Set3000HertzDataPoint(25)
                .Set4000HertzDataPoint(40)
                .Set6000HertzDataPoint(60)
                .Set8000HertzDataPoint(65)
                .Build();
            var right = AudiogramDatasetBuilder.Initialize()
                .Set125HertzDataPoint(15)
                .Set250HertzDataPoint(15)
                .Set500HertzDataPoint(25)
                .Set1000HertzDataPoint(20)
                .Set2000HertzDataPoint(35)
                .Set3000HertzDataPoint(20)
                .Set4000HertzDataPoint(45)
                .Set6000HertzDataPoint(65)
                .Set8000HertzDataPoint(60)
                .Build();
            var audiogram = Audiogram.Build(left, right);

            var left2 = AudiogramDatasetBuilder.Initialize()
                .Set125HertzDataPoint(10)
                .Set250HertzDataPoint(10)
                .Set500HertzDataPoint(10)
                .Set1000HertzDataPoint(10)
                .Set2000HertzDataPoint(10)
                .Set3000HertzDataPoint(10)
                .Set4000HertzDataPoint(10)
                .Set6000HertzDataPoint(10)
                .Set8000HertzDataPoint(10)
                .Build();
            var right2 = AudiogramDatasetBuilder.Initialize()
                .Set125HertzDataPoint(10)
                .Set250HertzDataPoint(10)
                .Set500HertzDataPoint(10)
                .Set1000HertzDataPoint(10)
                .Set2000HertzDataPoint(10)
                .Set3000HertzDataPoint(10)
                .Set4000HertzDataPoint(10)
                .Set6000HertzDataPoint(10)
                .Set8000HertzDataPoint(10)
                .Build();

            var audiogram2 = Audiogram.Build(left2, right2);

            return new List<AudiogramEntity>()
            {
                new AudiogramEntity(audiogram) { VisitId = XerMajestiesVisitGuid},
                new AudiogramEntity(audiogram2) { VisitId = BruceWaynesVisitGuid}
            };
        }
    }
}
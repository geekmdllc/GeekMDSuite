using System;
using System.Linq;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class AudiogramsRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
        
        [Fact]
        public void Update_GivenNewValues_PersistsChanges()
        {
            var audiogramBefore = _unitOfWork.Audiograms.All().First();
            var audiogramBeforeString = audiogramBefore.ToString();
            var index = audiogramBefore.Id;
            var newAudiogramEntity = NewAudiogramEntity(index);

            _unitOfWork.Audiograms.Update(newAudiogramEntity);
            _unitOfWork.Complete();

            var audiogramAfter = _unitOfWork.Audiograms.FindById(index);
            
            Assert.Equal(newAudiogramEntity.ToString(), audiogramAfter.ToString());
            Assert.NotEqual(audiogramBeforeString, audiogramAfter.ToString());
            VerifyAudiogramContents(audiogramAfter);
        }

        private static void VerifyAudiogramContents(AudiogramEntity audiogramAfter)
        {
            if (audiogramAfter == null) throw new ArgumentNullException(nameof(audiogramAfter));
            Assert.Contains("185", audiogramAfter.ToString());
            Assert.Contains("175", audiogramAfter.ToString());
            Assert.Contains("165", audiogramAfter.ToString());
            Assert.Contains("155", audiogramAfter.ToString());
            Assert.Contains("145", audiogramAfter.ToString());
            Assert.Contains("135", audiogramAfter.ToString());
            Assert.Contains("125", audiogramAfter.ToString());
            Assert.Contains("115", audiogramAfter.ToString());
            Assert.Contains("105", audiogramAfter.ToString());
            Assert.Contains("180", audiogramAfter.ToString());
            Assert.Contains("170", audiogramAfter.ToString());
            Assert.Contains("160", audiogramAfter.ToString());
            Assert.Contains("150", audiogramAfter.ToString());
            Assert.Contains("140", audiogramAfter.ToString());
            Assert.Contains("130", audiogramAfter.ToString());
            Assert.Contains("120", audiogramAfter.ToString());
            Assert.Contains("110", audiogramAfter.ToString());
            Assert.Contains("100", audiogramAfter.ToString());
        }

        private static AudiogramEntity NewAudiogramEntity(int index)
        {
            var newAudiogramEntity = new AudiogramEntity(Audiogram.Build(
                AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(100)
                    .Set250HertzDataPoint(110)
                    .Set500HertzDataPoint(120)
                    .Set1000HertzDataPoint(130)
                    .Set2000HertzDataPoint(140)
                    .Set3000HertzDataPoint(150)
                    .Set4000HertzDataPoint(160)
                    .Set6000HertzDataPoint(170)
                    .Set8000HertzDataPoint(180)
                    .Build(),
                AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(105)
                    .Set250HertzDataPoint(115)
                    .Set500HertzDataPoint(125)
                    .Set1000HertzDataPoint(135)
                    .Set2000HertzDataPoint(145)
                    .Set3000HertzDataPoint(155)
                    .Set4000HertzDataPoint(165)
                    .Set6000HertzDataPoint(175)
                    .Set8000HertzDataPoint(185)
                    .Build())
            );
            newAudiogramEntity.Id = index;
            return newAudiogramEntity;
        }
    }
}
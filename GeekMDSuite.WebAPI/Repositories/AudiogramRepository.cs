using System;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class AudiogramRepository : Repository<AudiogramEntity>, IAudiogramRepository
    {
        public AudiogramRepository(GeekMdSuiteDbContext context) : base (context)
        {
        }

        public override void Update(AudiogramEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            throw new System.NotImplementedException();
        }
    }
}
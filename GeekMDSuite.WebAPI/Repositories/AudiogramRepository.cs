using System;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class AudiogramRepository : Repository<AudiogramEntity>, IAudiogramRepository
    {
        public AudiogramRepository(GeekMdSuiteDbContext context)
        {
            _context = context;
        }

        public override void Update(AudiogramEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            throw new System.NotImplementedException();
        }
        
        private readonly GeekMdSuiteDbContext _context;
    }
}
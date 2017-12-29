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
            var entityToUpdate = FindById(entity.Id);
            entityToUpdate.Left.F125.Value = entity.Left.F125.Value;
            entityToUpdate.Left.F250.Value = entity.Left.F250.Value;
            entityToUpdate.Left.F500.Value = entity.Left.F500.Value;
            entityToUpdate.Left.F1000.Value = entity.Left.F1000.Value;
            entityToUpdate.Left.F2000.Value = entity.Left.F2000.Value;
            entityToUpdate.Left.F3000.Value = entity.Left.F3000.Value;
            entityToUpdate.Left.F4000.Value = entity.Left.F4000.Value;
            entityToUpdate.Left.F6000.Value = entity.Left.F6000.Value;
            entityToUpdate.Left.F8000.Value = entity.Left.F8000.Value;
            
            entityToUpdate.Right.F125.Value = entity.Right.F125.Value;
            entityToUpdate.Right.F250.Value = entity.Right.F250.Value;
            entityToUpdate.Right.F500.Value = entity.Right.F500.Value;
            entityToUpdate.Right.F1000.Value = entity.Right.F1000.Value;
            entityToUpdate.Right.F2000.Value = entity.Right.F2000.Value;
            entityToUpdate.Right.F3000.Value = entity.Right.F3000.Value;
            entityToUpdate.Right.F4000.Value = entity.Right.F4000.Value;
            entityToUpdate.Right.F6000.Value = entity.Right.F6000.Value;
            entityToUpdate.Right.F8000.Value = entity.Right.F8000.Value;
        }
    }
}
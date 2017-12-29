using GeekMDSuite.Procedures;

namespace GeekMDSuite.WebAPI.Models
{
    public class AudiogramEntity :  Audiogram, IEntity
    {
        public int Id { get; set; }
    }
}
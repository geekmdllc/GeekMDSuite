using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.WebAPI.Models
{
    public class AudiogramEntity :  Audiogram, IVisitData
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }

        public AudiogramEntity()
        { }

        public AudiogramEntity(Audiogram audiogram)
        {
            Left = audiogram.Left;
            Right = audiogram.Right;
        }
    }
}
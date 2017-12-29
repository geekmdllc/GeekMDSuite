using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.WebAPI.Models
{
    public class AudiogramEntity :  Audiogram, IVisitData
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}
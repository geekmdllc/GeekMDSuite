using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class AudiogramEntity : Audiogram, IVisitData<Audiogram>
    {
        public AudiogramEntity(Audiogram audiogram) : this()
        {
            MapValues(audiogram);
        }

        public AudiogramEntity()
        {
            Guid = Guid.Empty;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }

        public void MapValues(Audiogram subject)
        {
            Left.F125.Value = subject.Left.F125.Value;
            Left.F250.Value = subject.Left.F250.Value;
            Left.F500.Value = subject.Left.F500.Value;
            Left.F1000.Value = subject.Left.F1000.Value;
            Left.F2000.Value = subject.Left.F2000.Value;
            Left.F3000.Value = subject.Left.F3000.Value;
            Left.F4000.Value = subject.Left.F4000.Value;
            Left.F6000.Value = subject.Left.F6000.Value;
            Left.F8000.Value = subject.Left.F8000.Value;

            Right.F125.Value = subject.Right.F125.Value;
            Right.F250.Value = subject.Right.F250.Value;
            Right.F500.Value = subject.Right.F500.Value;
            Right.F1000.Value = subject.Right.F1000.Value;
            Right.F2000.Value = subject.Right.F2000.Value;
            Right.F3000.Value = subject.Right.F3000.Value;
            Right.F4000.Value = subject.Right.F4000.Value;
            Right.F6000.Value = subject.Right.F6000.Value;
            Right.F8000.Value = subject.Right.F8000.Value;
        }
    }
}
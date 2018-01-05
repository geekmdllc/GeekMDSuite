using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class ComorbidityEntity : Comorbidity, IEntity<Comorbidity>
    {
        public int Id { get; set; }

        public void MapValues(Comorbidity subject)
        {
            Illness = subject.Illness;
        }
    }
}
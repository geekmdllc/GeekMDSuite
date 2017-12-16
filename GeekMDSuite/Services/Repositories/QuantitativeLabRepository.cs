using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeekMDSuite.LaboratoryData;
using Newtonsoft.Json;

namespace GeekMDSuite.Services.Repositories
{
    public static class QuantitativeLabRepository
    {
        public static IEnumerable<QuantitativeLabInterpretationModel> GetAllLabs()
        {
            //todo: Get current working file dir from assembly rather than relative from test.
            var jsonFile = File.ReadAllText("../../../../GeekMDSuite/Services/Repositories/quantitative_labs.json");
            return JsonConvert.DeserializeObject<List<QuantitativeLabInterpretationModel>>(jsonFile);
        }

        public static QuantitativeLabInterpretationModel GetLab(QuantitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
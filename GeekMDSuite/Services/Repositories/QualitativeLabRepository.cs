using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Helpers;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Interpretation;
using Newtonsoft.Json;

namespace GeekMDSuite.Services.Repositories
{
    internal static class QualitativeLabRepository
    {
        public static IEnumerable<QualitativeLabInterpretationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("qualitative_labs.json");
            return JsonConvert.DeserializeObject<List<QualitativeLabInterpretationModel>>(jsonFile);
        }

        public static QualitativeLabInterpretationModel GetLab(QualitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
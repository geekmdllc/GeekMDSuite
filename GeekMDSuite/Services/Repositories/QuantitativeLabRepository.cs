using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Helpers;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Interpretation;
using Newtonsoft.Json;

namespace GeekMDSuite.Services.Repositories
{
    internal static class QuantitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QuantitativeLabInterpretationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("quantitative_labs.json");
            return JsonConvert.DeserializeObject<List<QuantitativeLabInterpretationModel>>(jsonFile);
        }

        public static QuantitativeLabInterpretationModel GetLab(IQuantitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
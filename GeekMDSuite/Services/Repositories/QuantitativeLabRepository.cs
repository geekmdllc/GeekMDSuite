using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Helpers;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Newtonsoft.Json;

namespace GeekMDSuite.Services.Repositories
{
    internal static class QuantitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QuantitativeLabClassificationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("quantitative_labs.json");
            return JsonConvert.DeserializeObject<List<QuantitativeLabClassificationModel>>(jsonFile);
        }

        public static QuantitativeLabClassificationModel GetLab(IQuantitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
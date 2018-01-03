using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Helpers;
using GeekMDSuite.Core.LaboratoryData;
using Newtonsoft.Json;

namespace GeekMDSuite.Analytics.Repositories
{
    internal static class QuantitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QuantitativeLabClassificationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("quantitative_labs.json");
            return JsonConvert.DeserializeObject<List<QuantitativeLabClassificationModel>>(jsonFile);
        }

        public static QuantitativeLabClassificationModel GetLab(QuantitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
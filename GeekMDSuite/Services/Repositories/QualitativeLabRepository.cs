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
    internal static class QualitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QualitativeLabClassificationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("qualitative_labs.json");
            return JsonConvert.DeserializeObject<List<QualitativeLabClassificationModel>>(jsonFile);
        }

        public static QualitativeLabClassificationModel GetLab(IQualitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
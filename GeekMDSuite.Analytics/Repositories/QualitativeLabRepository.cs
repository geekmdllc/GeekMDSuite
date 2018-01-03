using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Helpers;
using GeekMDSuite.Core.LaboratoryData;
using Newtonsoft.Json;

namespace GeekMDSuite.Analytics.Repositories
{
    internal static class QualitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QualitativeLabClassificationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("qualitative_labs.json");
            return JsonConvert.DeserializeObject<List<QualitativeLabClassificationModel>>(jsonFile);
        }

        public static QualitativeLabClassificationModel GetLab(QualitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
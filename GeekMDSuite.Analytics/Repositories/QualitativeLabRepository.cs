using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Utilities.Helpers;
using Newtonsoft.Json;

namespace GeekMDSuite.Analytics.Repositories
{
    internal static class QualitativeLabRepository
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<QualitativeLabClassificationModel> GetAllLabs()
        {
            var jsonFile = ReflectionHelper.GetAssetFromExecutingAssembly("qualitative_labs.json");
            return JsonConvert.DeserializeObject<List<QualitativeLabClassificationModel>>(jsonFile);
        }

        public static QualitativeLabClassificationModel GetLab(QualitativeLab lab)
        {
            return GetAllLabs().First(l =>
                string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
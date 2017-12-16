using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using GeekMDSuite.Helpers;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Interpretation;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json;

namespace GeekMDSuite.Services.Repositories
{
    public static class QuantitativeLabRepository
    {
        public static IEnumerable<QuantitativeLabInterpretationModel> GetAllLabs()
        {
            var jsonFile = Reflection.GetAssetFromExecutingAssembly("quantitative_labs.json");
            return JsonConvert.DeserializeObject<List<QuantitativeLabInterpretationModel>>(jsonFile);
        }

        public static QuantitativeLabInterpretationModel GetLab(QuantitativeLab lab) => 
            GetAllLabs().First(l => string.Equals(l.LabName.ToString(), lab.Type.ToString(), StringComparison.CurrentCultureIgnoreCase));
    }
}
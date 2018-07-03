using System;
using System.Text;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    public class EntityDataFindFilter
    {
        public Guid? VisitGuid { get; set; }
        public int? Offset { get; set; }
        public int? Take { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (VisitGuid.IsNotNullOrEmtpy()) builder.Append($"{nameof(VisitGuid)}={VisitGuid}");
            if (Offset != null) builder.Append($"{nameof(Offset)}={Offset}");
            if (Take != null) builder.Append($"{nameof(Take)}={Take}");

            return string.Join("&", builder);
        }
    }
}
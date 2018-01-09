using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.StatusCodeResults
{
    public class ConflictResult : ObjectResult
    {
        public ConflictResult(object obj) : base(obj)
        {
            StatusCode = 409;
        }
    }
}
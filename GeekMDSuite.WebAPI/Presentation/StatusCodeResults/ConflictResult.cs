using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.StatusCodeResults
{
    public class ConflictResult : StatusCodeResult
    {
        public ConflictResult() : base(409)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static List<VisitEntity> GetVisitEntities()
        {
            return new List<VisitEntity>
            {
                
                new VisitEntity()
                {
                    Date = new DateTime(2017, 1, 1),
                    Patient = Guid.Parse("50345ee6-fde2-4a51-8177-8c715628e39e"),
                    Visit = Guid.Parse("8bfb8f23-39f4-4cde-80c6-72b178068dc4"),
                },
                new VisitEntity()
                {
                    Date = new DateTime(2016, 1, 1),
                    Patient = Guid.Parse("3b69bd30-7a07-4859-b536-5071e0a5f516"),
                    Visit = Guid.Parse("fef15e44-74cb-4c21-aba5-d6363c45108d")
                }
            };
        }
    }
}
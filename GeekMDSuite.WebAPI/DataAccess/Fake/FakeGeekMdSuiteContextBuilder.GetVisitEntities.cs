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
                    Patient = BruceWayneGuid,
                    Visit = BruceWaynesVisitGuid,
                },
                new VisitEntity()
                {
                    Date = new DateTime(2016, 1, 1),
                    Patient = XerMajestyGuid,
                    Visit = XerMajestiesVisitGuid
                }
            };
        }
    }
}
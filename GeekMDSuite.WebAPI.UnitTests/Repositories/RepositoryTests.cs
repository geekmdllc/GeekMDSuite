using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        private readonly IUnitOfWork _unitOfWorkSeeded = new FakeUnitOfWorkSeeded();
        private readonly IUnitOfWork _unitOfWorkEmpty = new FakeUnitOfWorkEmpty();
    }
    
}
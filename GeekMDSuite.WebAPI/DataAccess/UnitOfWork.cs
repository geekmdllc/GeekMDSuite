﻿using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Audiograms = new AudiogramsRepository(_context);
            BloodPressures = new BloodPressuresRepository(_context);
            CarotidUltrasounds = new CarotidUltrasoundsRepository(_context);
            CentralBloodPressures = new CentralBloodPressuresRepository(_context);
            FunctionalMovementScreens = new FunctionalMovementScreensRepository(_context);
            GripStrengths = new GripStrengthsRepository(_context);
            OcularPressures = new OcularPressuresRepository(_context);
            Patients = new PatientsRepository(_context);
            Visits = new VisitsRepository(_context);
            PeripheralVisions = new PeripheralVisionsRepository(_context);
        }

        public IRepository<T> Repository<T>() where T : class, IEntity<T> => new Repository<T>(_context);
        public IAudiogramsRepository Audiograms { get;  }
        public IBloodPressuresRepository BloodPressures { get;  }
        public ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        public ICentralBloodPressureRepository CentralBloodPressures { get; }
        public IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        public IGripStrengthsRepository GripStrengths { get;  }
        public IOcularPressuresRepository OcularPressures { get; }
        public IPatientsRepository Patients { get; }
        public IPeripheralVisionsRepository PeripheralVisions { get; set; }
        public IVisitRepository Visits { get;  }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


        private readonly GeekMdSuiteDbContext _context;
    }
}
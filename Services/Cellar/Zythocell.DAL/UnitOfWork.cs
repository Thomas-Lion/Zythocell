using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Interfaces;
using Zythocell.Common.Interfaces.IRepositories;
using Zythocell.DAL.Context;
using Zythocell.DAL.Repositories;

namespace Zythocell.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZythocellContext Context;
        private bool disposed = false;

        private IBeverageRepository beverageRepository;
        private ICellarRepository cellarRepository;
        private IRateRepository rateRepository;

        public UnitOfWork(ZythocellContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IBeverageRepository BeverageRepository => beverageRepository ??= new BeverageRepository(Context);
        public ICellarRepository CellarRepository => cellarRepository ??= new CellarRepository(Context);
        public IRateRepository RateRepository => rateRepository ??= new RateRepository(Context);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}

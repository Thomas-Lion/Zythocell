using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.Interfaces.IRepositories;

namespace Zythocell.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBeverageRepository BeverageRepository { get; }
        ICellarRepository CellarRepository { get; }
        IRateRepository RateRepository { get; }
        void SaveChanges();
    }
}

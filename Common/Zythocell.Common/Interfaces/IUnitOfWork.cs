using System;
using System.Collections.Generic;
using System.Text;

namespace Zythocell.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

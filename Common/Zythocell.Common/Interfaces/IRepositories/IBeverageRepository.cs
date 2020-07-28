using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.Interfaces.IRepositories
{
    public interface IBeverageRepository : IRepository<BeverageTO>
    {
        public bool Delete(BeverageTO entity);        
    }
}

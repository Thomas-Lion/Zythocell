using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.IRepositories
{
    public interface IBeverageRepository : IRepository<BeverageTO>
    {
        public ICollection<BeverageTO> GetAll();
        public bool Delete(BeverageTO entity);        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.Interfaces.IRepositories
{ 
    public interface IRateRepository : IRepository<RateTO>
    {
        public List<RateTO> OrderByRate(Guid userId);
        public ICollection<RateTO> GetByUser(Guid userId);
    }
}

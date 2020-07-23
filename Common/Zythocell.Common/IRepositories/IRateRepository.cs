using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.IRepositories
{
    public interface IRateRepository : IRepository<RateTO>
    {
        public List<RateTO> OrderByRate(string userId);
        public ICollection<RateTO> GetByUser(string userId);
    }
}

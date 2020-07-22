using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.IRepositories
{
    public interface IRateRepository : IRepository<RateTO>
    {
        public ICollection<RateTO> OrderByRate(Guid userId);
        public ICollection<RateTO> GetByUser(Guid userId);
    }
}

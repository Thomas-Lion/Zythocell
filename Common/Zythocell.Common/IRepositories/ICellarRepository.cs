using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.IRepositories
{
    public interface ICellarRepository : IRepository<CellarTO>
    {
        public ICollection<CellarTO> GetByUser(string userId);
        public List<CellarTO> OrderByDate(string userId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.IRepositories
{
    public interface ICellarRepository : IRepository<CellarTO>
    {
        public ICollection<CellarTO> GetByUser(Guid userId);
        public ICollection<CellarTO> OrderByDate(Guid userId);
    }
}

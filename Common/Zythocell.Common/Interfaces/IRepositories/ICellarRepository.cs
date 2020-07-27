using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.Common.TransferObject;

namespace Zythocell.Common.Interfaces.IRepositories
{
    public interface ICellarRepository : IRepository<CellarTO>
    {
        public ICollection<CellarTO> GetByUser(Guid userId);
        public List<CellarTO> OrderByDate(Guid userId);
    }
}

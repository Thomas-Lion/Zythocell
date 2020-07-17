using System;
using System.Collections.Generic;
using System.Text;
using Zythocell.DAL.Entities;

namespace Zythocell.DAL.Repositories
{
    public interface IRateRepository : IRepository<Rate>
    {
        public ICollection<Rate> OrderByRate(Guid userId);
        public ICollection<Rate> GetByUser(Guid userId);
    }
}
